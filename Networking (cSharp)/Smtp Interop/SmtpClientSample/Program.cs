/**
 * Простой пример почтового клиента
 */

using System.Net.Mail;
using System.Net.Mime;

namespace SmtpClientSample
{
   class Program
   {
      private const string MailHost = "/*TODO: Enter your host here*/";

      static void Main()
      {
         var smtpClient = new SmtpClient { Host = MailHost };
         var mailMessage = new MailMessage { Sender = new MailAddress("dwinner@inbox.ru", "dwinner") };
         mailMessage.To.Add(new MailAddress("editor@wrox.com", "Paul Reese"));
         mailMessage.To.Add(new MailAddress("marketing@wrox.com", "Wrox Marketing"));
         mailMessage.CC.Add(new MailAddress("publisher@wrox.com", "Barry Pruett"));
         mailMessage.Subject = "The latest chapter";
         mailMessage.Body = "<b>Here you can put a long message</b>";
         mailMessage.IsBodyHtml = true;
         mailMessage.Priority = MailPriority.High;
         const string attFile = "Sliders.rar";
         var mailAttachment = new Attachment(attFile, MediaTypeNames.Application.Zip);
         mailMessage.Attachments.Add(mailAttachment);
         smtpClient.Send(mailMessage);
      }
   }
}
