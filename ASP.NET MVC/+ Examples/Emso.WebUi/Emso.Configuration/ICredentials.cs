namespace Emso.Configuration
{
   public interface ICredentials
   {
      string FromAddress { get; set; }
      string FromDisplayName { get; set; }
      string MailLogin { get; set; }
      string MailPassword { get; set; }
      string SmtpServerName { get; set; }
      int SmtpPort { get; set; }
   }
}