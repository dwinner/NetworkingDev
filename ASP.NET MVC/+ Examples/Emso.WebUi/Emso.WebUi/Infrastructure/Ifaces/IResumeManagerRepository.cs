using System.Collections.Generic;
using System.Threading.Tasks;
using Emso.WebUi.Models;
using Emso.WebUi.Utils;
using EmsoHr.Entities;

namespace Emso.WebUi.Infrastructure.Ifaces
{
   /// <summary>
   ///    Interface for managing the user resumes
   /// </summary>
   public interface IResumeManagerRepository
   {
      /// <summary>
      ///    Getting all files
      /// </summary>
      /// <param name="aSessionId">Session identifier</param>
      /// <param name="aMimeTypeId">Mime type identifier</param>
      /// <returns>All files</returns>
      Task<IEnumerable<UploadedFileInfo>> GetFilesAsync(string aSessionId, MimeTypeId aMimeTypeId);

      /// <summary>
      ///    Delete file
      /// </summary>
      /// <param name="aSessionId">Session idenfier</param>
      /// <param name="aFileName">Mime type identifier</param>
      /// <returns>True if file has been successfully deleted, false otherwise</returns>
      Task<bool> DeleteAsync(string aSessionId, string aFileName);

      /// <summary>
      ///    Delete all session files
      /// </summary>
      /// <param name="aSessionId">Session idenfier</param>
      /// <returns>True if files has been successfully deleted, false otherwise</returns>
      Task<bool> DeleteAsync(string aSessionId);

      /// <summary>
      ///    Upload file
      /// </summary>
      /// <param name="aResume">Resume</param>
      /// <returns>True if file has been successfully uploaded, false otherwise</returns>
      Task<bool> UploadFileAsync(SpontaneousResume aResume);

      /// <summary>
      ///    Get uploaded count
      /// </summary>
      /// <param name="aSessionId">Session identifier</param>
      /// <param name="aMimeTypeId">Mime type identifier</param>
      /// <returns>Uploaded count</returns>
      Task<int> GetUploadedCountAsync(string aSessionId, MimeTypeId aMimeTypeId);
   }
}