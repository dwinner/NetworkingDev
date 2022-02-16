using System;

namespace SportsStore.Domain.Concrete
{
   public class EmailSettings
   {
      public EmailSettings()
      {
         MailToAddress = "dwinner@inbox.ru";
         MailFromAddress = "noreply@viva64.com";
         UseSsl = true;
         UserName = "u388423";
         Password = "2853a0ad1jk";
         ServerName = "smtp-19.1gb.ru";
         ServerPort = 25;
         WriteAsFile = true;
         FileLocation = Environment.CurrentDirectory;
      }

      public string MailToAddress { get; private set; }
      public string MailFromAddress { get; private set; }
      public bool UseSsl { get; private set; }
      public string UserName { get; private set; }
      public string Password { get; private set; }
      public string ServerName { get; private set; }
      public int ServerPort { get; private set; }
      public bool WriteAsFile { get; set; }
      public string FileLocation { get; private set; }
   }
}