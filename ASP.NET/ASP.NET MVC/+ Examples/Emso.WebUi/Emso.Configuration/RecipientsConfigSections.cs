using System.Configuration;

namespace Emso.Configuration
{
   public sealed class RecipientsConfigSections : ConfigurationSection
   {
      private const string RecipientsSectionName = "Recipients";

      [ConfigurationProperty(RecipientsSectionName)]
      public RecipientCollection Recipients
      {
         get { return (RecipientCollection) base[RecipientsSectionName]; }
      }
   }
}