using System.Collections.Generic;
using System.Threading.Tasks;
using Emso.Configuration;
using Emso.WebUi.Models;
using Emso.WebUi.ViewModels;

namespace Emso.WebUi.Infrastructure.Ifaces
{
   /// <summary>
   ///    Interface for sending contact information
   /// </summary>
   public interface IContactSender
   {
      /// <summary>
      ///    Send information about contact
      /// </summary>
      /// <param name="aPerson">A person who contacts</param>
      /// <param name="resumeFiles">Resume files</param>
      /// <param name="codeExampleFiles">Code example files</param>
      /// <param name="credentials">Credentials</param>
      /// <param name="recipients">Recipient collection</param>
      /// <returns>true, if successfully sending contact information, false otherwise</returns>
      Task<bool> ContactUsAsync(ContactPersonViewModel aPerson,
         IEnumerable<UploadedFileInfo> resumeFiles,
         IEnumerable<UploadedFileInfo> codeExampleFiles,
         ICredentials credentials,
         IRecipientCollection recipients);
   }
}