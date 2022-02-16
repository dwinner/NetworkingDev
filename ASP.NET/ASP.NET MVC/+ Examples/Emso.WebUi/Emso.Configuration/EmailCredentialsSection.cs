using System.Configuration;

namespace Emso.Configuration
{
   public sealed class EmailCredentialsSection : ConfigurationSection
   {
      static EmailCredentialsSection()
      {
         Config = ConfigurationManager.GetSection("EmailCredentials") as EmailCredentialsSection ??
                  new EmailCredentialsSection();
      }

      private const string FromAddressPropertyName = "fromAddress";
      private const string FromDisplayNamePropertyName = "fromDisplayName";
      private const string MailLoginPropertyName = "mailLogin";
      private const string MailPasswordPropertyName = "mailPassword";
      private const string SmtpServerNamePropertyName = "smtpServerName";
      private const string SmtpPortPropertyName = "smtpPort";

      public static EmailCredentialsSection Config { get; private set; }

      [ConfigurationProperty(FromAddressPropertyName, IsRequired = true)]
      public string FromAddress
      {
         get { return (string) this[FromAddressPropertyName]; }
         set { this[FromAddressPropertyName] = value; }
      }

      [ConfigurationProperty(FromDisplayNamePropertyName, IsRequired = true)]
      public string FromDisplayName
      {
         get { return (string) this[FromDisplayNamePropertyName]; }
         set { this[FromDisplayNamePropertyName] = value; }
      }

      [ConfigurationProperty(MailLoginPropertyName, IsRequired = true)]
      public string MailLogin
      {
         get { return (string) this[MailLoginPropertyName]; }
         set { this[MailLoginPropertyName] = value; }
      }

      [ConfigurationProperty(MailPasswordPropertyName, IsRequired = true)]
      public string MailPassword
      {
         get { return (string) this[MailPasswordPropertyName]; }
         set { this[MailPasswordPropertyName] = value; }
      }

      [ConfigurationProperty(SmtpServerNamePropertyName, IsRequired = true, IsKey = true)]
      public string SmtpServerName
      {
         get { return (string) this[SmtpServerNamePropertyName]; }
         set { this[SmtpServerNamePropertyName] = value; }
      }

      [ConfigurationProperty(SmtpPortPropertyName, IsRequired = true)]
      public int SmtpPort
      {
         get { return (int) this[SmtpPortPropertyName]; }
         set { this[SmtpPortPropertyName] = value; }
      }
   }
}