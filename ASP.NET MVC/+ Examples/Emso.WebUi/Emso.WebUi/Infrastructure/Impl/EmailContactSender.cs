using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Emso.Configuration;
using Emso.WebUi.Infrastructure.Exceptions;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Models;
using Emso.WebUi.Properties;
using Emso.WebUi.Utils;
using Emso.WebUi.ViewModels;
using ICredentials = Emso.Configuration.ICredentials;

namespace Emso.WebUi.Infrastructure.Impl
{
   /// <summary>
   ///    Email implementation for sending contact information
   /// </summary>
   public sealed class EmailContactSender : IContactSender
   {
      private static readonly Encoding _DefaultEncoding = Encoding.UTF8;
      private static readonly ContentType _PdfContentType = new ContentType(MimeTypeId.Pdf.GetMimeTypes()[0]);
      private static readonly ContentType _ZipContentType = new ContentType(MimeTypeId.Zip.GetMimeTypes()[0]);

      /// <summary>
      ///    Send information about contact
      /// </summary>
      /// <param name="aPerson">A person who contacts</param>
      /// <param name="resumeFiles">Resume files</param>
      /// <param name="codeExampleFiles">Code example files</param>
      /// <param name="credentials">Credentials</param>
      /// <param name="recipients">Recipient collection</param>
      /// <returns>true, if successfully sending contact information, false otherwise</returns>
      public async Task<bool> ContactUsAsync(ContactPersonViewModel aPerson,
         IEnumerable<UploadedFileInfo> resumeFiles,
         IEnumerable<UploadedFileInfo> codeExampleFiles,
         ICredentials credentials,
         IRecipientCollection recipients)
      {
         var smtpClient = new SmtpClient(credentials.SmtpServerName, credentials.SmtpPort)
         {
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(credentials.MailLogin, credentials.MailPassword)
         };

         string messageBody = aPerson.GenerateMessageBody();
         var fromAddr = new MailAddress(credentials.FromAddress, credentials.FromDisplayName, _DefaultEncoding);
         var emailRecipients = recipients.Recipients;
         var mailAddresses =
            emailRecipients.Select(
               recipient => new MailAddress(recipient.ToAddress, recipient.ToDisplayName, _DefaultEncoding)).ToList();

         foreach (MailAddress toAddr in mailAddresses)
         {
            using (var message = new MailMessage(fromAddr, toAddr)
            {
               Subject = string.Format("Resume: {0} {1}", aPerson.FirstName, aPerson.LastName),
               Body = messageBody,
               DeliveryNotificationOptions = DeliveryNotificationOptions.None,
               SubjectEncoding = _DefaultEncoding
            })
            {
               foreach (Attachment attachment in GenerateAttachments(resumeFiles, codeExampleFiles))
               {
                  message.Attachments.Add(attachment);
               }

               try
               {
                  await smtpClient.SendMailAsync(message).ConfigureAwait(false);
               }
               catch (InvalidOperationException invalidOperationEx)
               {
                  throw new SendingMailException(Resources.ErrorSendingEmail, invalidOperationEx);
               }
               catch (SmtpFailedRecipientException smtpFailedRecipientEx)
               {
                  throw new SendingMailException(Resources.ErrorSendingEmail, smtpFailedRecipientEx);
               }
               catch (SmtpException smtpEx)
               {
                  throw new SendingMailException(Resources.ErrorSendingEmail, smtpEx);
               }               
            }
         }
         
         return true;
      }

      private static IEnumerable<Attachment> GenerateAttachments(IEnumerable<UploadedFileInfo> resumeFiles,
         IEnumerable<UploadedFileInfo> codeExampleFiles)
      {
         var resumes = GetAttachments(resumeFiles, _PdfContentType);
         var codeExamples = GetAttachments(codeExampleFiles, _ZipContentType);         
         return resumes.Union(codeExamples);
      }

      private static IEnumerable<Attachment> GetAttachments(IEnumerable<UploadedFileInfo> fileInfos, ContentType contentType)
      {
         return
         (from uploadedFileInfo in fileInfos
            let stream = new MemoryStream(uploadedFileInfo.Content)
            select new Attachment(stream, contentType)).ToList();
      }
   }
}