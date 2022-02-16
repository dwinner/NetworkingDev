namespace Emso.Configuration
{
   public sealed class ConfigCredentials : ICredentials
   {
      private readonly EmailCredentialsSection _emailCredentialsSection = EmailCredentialsSection.Config;

      public string FromAddress
      {
         get { return _emailCredentialsSection.FromAddress; }
         set { _emailCredentialsSection.FromAddress = value; }
      }

      public string FromDisplayName
      {
         get { return _emailCredentialsSection.FromDisplayName; }
         set { _emailCredentialsSection.FromDisplayName = value; }
      }

      public string MailLogin
      {
         get { return _emailCredentialsSection.MailLogin; }
         set { _emailCredentialsSection.MailLogin = value; }
      }

      public string MailPassword
      {
         get { return _emailCredentialsSection.MailPassword; }
         set { _emailCredentialsSection.MailPassword = value; }
      }

      public string SmtpServerName
      {
         get { return _emailCredentialsSection.SmtpServerName; }
         set { _emailCredentialsSection.SmtpServerName = value; }
      }

      public int SmtpPort
      {
         get { return _emailCredentialsSection.SmtpPort; }
         set { _emailCredentialsSection.SmtpPort = value; }
      }

      public override string ToString()
      {
         return
            string.Format(
               "FromAddress: {0}, FromDisplayName: {1}, MailLogin: {2}, MailPassword: {3}, SmtpServerName: {4}, SmtpPort: {5}",
               FromAddress, FromDisplayName, MailLogin, MailPassword, SmtpServerName, SmtpPort);
      }
   }
}