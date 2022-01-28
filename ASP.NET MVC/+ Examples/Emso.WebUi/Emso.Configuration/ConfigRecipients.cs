using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Emso.Configuration
{
   public sealed class ConfigRecipients : IRecipientCollection
   {
      public IEnumerable<EmailRecipient> Recipients
      {
         get
         {
            var recipientsConfigSections =
               ConfigurationManager.GetSection("EmailRecipients") as RecipientsConfigSections;
            if (recipientsConfigSections != null)
            {
               return (from RecipientElement recipient in recipientsConfigSections.Recipients
                       select new EmailRecipient
                       {
                          ToDisplayName = recipient.DisplayName,
                          ToAddress = recipient.Address
                       }).ToList();
            }

            throw new InvalidOperationException("Section 'EmailRecipients' not registered in App.config");
         }
      }
   }
}