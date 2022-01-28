using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Models;
using Emso.WebUi.Properties;
using Emso.WebUi.Utils;
using EmsoHr.Entities;

namespace Emso.WebUi.Services
{
   /// <summary>
   ///    File upload WebAPI controller limited by session state
   /// </summary>
   [RoutePrefix("upload")]
   public class SessionLimitedFileUploadController : ApiController
   {
      public const string FileFormDataKey = "fileNameToDelete";
      private readonly IResumeManagerRepository _resumeManagerRepository;

      public SessionLimitedFileUploadController(IResumeManagerRepository resumeManagerRepository)
      {
         _resumeManagerRepository = resumeManagerRepository;
      }

      [Route("getAll/{mimeId:int}")]
      public async Task<IEnumerable<UploadedFileInfo>> GetAsync(MimeTypeId mimeId)
      {
         var context = HttpContext.Current;
         var sessionId = context.GetSessionId();
         var uploadedFileInfos = await _resumeManagerRepository.GetFilesAsync(sessionId, mimeId).ConfigureAwait(false);
         return uploadedFileInfos;
      }

      [Route("del")]
      public async Task<HttpResponseMessage> DeleteAsync(FormDataCollection formData)
      {
         var context = HttpContext.Current;
         var fileName = formData[FileFormDataKey];
         var sessionId = context.GetSessionId();
         var successfullyDeleted =
            await _resumeManagerRepository.DeleteAsync(sessionId, fileName).ConfigureAwait(false);
         if (!successfullyDeleted)
         {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
               ReasonPhrase = string.Format(Resources.FileNotExists, fileName)
            };
         }

         return new HttpResponseMessage(HttpStatusCode.OK)
         {
            ReasonPhrase = string.Format(Resources.FileSuccessfullyDeleted, fileName)
         };
      }

      [Route("execute/{mimeId:int}")]
      public async Task<IHttpActionResult> PostAsync(MimeTypeId mimeId)
      {
         if (!Request.Content.IsMimeMultipartContent())
         {
            return BadRequest(Resources.UploadingNotSupported);
         }

         var context = HttpContext.Current;

         #region Checking the upload limit

         var sessionId = context.GetSessionId();
         var uploadCount =
            await _resumeManagerRepository.GetUploadedCountAsync(sessionId, mimeId).ConfigureAwait(false);
         if (uploadCount >= mimeId.GetUploadLimit())
         {
            return BadRequest(string.Format(Resources.ExceededUploadedLimit, mimeId));
         }

         #endregion

         var provider = new MultipartMemoryStreamProvider();
         await Request.Content.ReadAsMultipartAsync(provider).ConfigureAwait(false);
         foreach (var content in provider.Contents)
         {
            #region Checking media types

            var headers = content.Headers;
            var mediaType = headers.ContentType.MediaType;
            var contentLength = headers.ContentLength;
            var availableMimeTypes = mimeId.GetMimeTypes();
            if (availableMimeTypes.All(availableMimeType => availableMimeType != mediaType))
            {
               return BadRequest(string.Format(Resources.WrongMimeType, mediaType));
            }

            #endregion

            var fileName = headers.ContentDisposition.FileName.Trim('\"');
            var fileBytes = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var newResume = new SpontaneousResume
            {
               SessionId = sessionId,
               File = fileBytes,
               FileName = fileName,
               FileType = mimeId.ToString(),
               FileSize = contentLength ?? default(decimal)
            };
            if (!await _resumeManagerRepository.UploadFileAsync(newResume).ConfigureAwait(false))
            {
               return BadRequest(string.Format(Resources.FileExists, fileName));
            }
         }

         return Ok(Resources.FileUploaded);
      }
   }
}