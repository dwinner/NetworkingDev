using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Models;
using Emso.WebUi.Utils;
using EmsoHr.Entities;

namespace Emso.WebUi.Infrastructure.Impl
{
   /// <summary>
   ///    Resume manager database implementation
   /// </summary>
   public sealed class DatabaseResumeManager : IResumeManagerRepository
   {
      private readonly EmsoHrEntities _hrEntities = new EmsoHrEntities();

      /// <summary>
      ///    Getting all files
      /// </summary>
      /// <param name="aSessionId">Session identifier</param>
      /// <param name="aMimeTypeId">Mime type identifier</param>
      /// <returns>All files</returns>
      public async Task<IEnumerable<UploadedFileInfo>> GetFilesAsync(string aSessionId, MimeTypeId aMimeTypeId)
      {
         var resumes =
            _hrEntities.SpontaneousResumes.Where(
               resume => resume.SessionId == aSessionId && resume.FileType == aMimeTypeId.ToString());
         var uploads = new List<UploadedFileInfo>();
         await resumes.ForEachAsync(resume =>
         {
            uploads.Add(new UploadedFileInfo
            {
               Name = resume.FileName,
               Size = resume.FileSize,
               Content = resume.File,
               MimeType = resume.FileType
            });
         }).ConfigureAwait(false);

         return uploads;
      }

      /// <summary>
      ///    Delete file
      /// </summary>
      /// <param name="aSessionId">Session idenfier</param>
      /// <param name="aFileName">Mime type identifier</param>
      /// <returns>True if file has been successfully deleted, false otherwise</returns>
      public async Task<bool> DeleteAsync(string aSessionId, string aFileName)
      {
         var affected = 0;
         var resumeToDelete =
            await
               _hrEntities.SpontaneousResumes.FirstOrDefaultAsync(
                  resume => resume.SessionId == aSessionId && resume.FileName == aFileName).ConfigureAwait(false);
         if (resumeToDelete != null)
         {
            _hrEntities.SpontaneousResumes.Remove(resumeToDelete);
            affected += await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         }

         return affected > 0;
      }

      /// <summary>
      ///    Delete all session files
      /// </summary>
      /// <param name="aSessionId">Session idenfier</param>
      /// <returns>True if files has been successfully deleted, false otherwise</returns>
      public async Task<bool> DeleteAsync(string aSessionId)
      {
         var affected = 0;
         var sessionResumes = _hrEntities.SpontaneousResumes.Where(resume => resume.SessionId == aSessionId);
         _hrEntities.SpontaneousResumes.RemoveRange(sessionResumes);
         affected += await _hrEntities.SaveChangesAsync().ConfigureAwait(false);

         return affected > 0;
      }

      /// <summary>
      ///    Upload file
      /// </summary>
      /// <param name="aResume">Resume</param>
      /// <returns>True if file has been successfully uploaded, false otherwise</returns>
      public async Task<bool> UploadFileAsync(SpontaneousResume aResume)
      {
         _hrEntities.SpontaneousResumes.Add(aResume);
         var affected = await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         return affected > 0;
      }

      /// <summary>
      ///    Get uploaded count
      /// </summary>
      /// <param name="aSessionId">Session identifier</param>
      /// <param name="aMimeTypeId">Mime type identifier</param>
      /// <returns>Uploaded count</returns>
      public async Task<int> GetUploadedCountAsync(string aSessionId, MimeTypeId aMimeTypeId)
      {
         return await
            _hrEntities.SpontaneousResumes.CountAsync(
                  resume => resume.SessionId == aSessionId && resume.FileType == aMimeTypeId.ToString())
               .ConfigureAwait(false);
      }
   }
}