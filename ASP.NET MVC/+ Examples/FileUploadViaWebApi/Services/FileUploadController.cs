using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FileUploadViaWebApi.Services
{
   [RoutePrefix("upload")]
   public class FileUploadController : ApiController
   {
      [Route("files")]
      public async Task<IHttpActionResult> Post()
      {
         if (!Request.Content.IsMimeMultipartContent())
         {
            return BadRequest();
         }

         var provider = new MultipartMemoryStreamProvider();
         var root = HttpContext.Current.Server.MapPath("~/Uploaded/");
         /*var streamProvider = */
         await Request.Content.ReadAsMultipartAsync(provider);

         foreach (var file in provider.Contents)
         {
            var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
            var fileArray = await file.ReadAsByteArrayAsync();

            using (var fileStream = new FileStream(string.Format("{0}{1}", root, fileName), FileMode.Create))
            {
               await fileStream.WriteAsync(fileArray, 0, fileArray.Length);
            }
         }

         return Ok("File uploaded");
      }
   }
}