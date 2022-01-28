using System.Configuration;

namespace Emso.Configuration
{
   public sealed class RecipientElement : ConfigurationElement
   {
      private const string DisplayNameAttrubuteKey = "displayName";
      private const string AddressAttributeKey = "address";

      [ConfigurationProperty(DisplayNameAttrubuteKey, DefaultValue = "", IsKey = false, IsRequired = true)]
      public string DisplayName
      {
         get { return (string) base[DisplayNameAttrubuteKey]; }
      }

      [ConfigurationProperty(AddressAttributeKey, DefaultValue = "", IsKey = true, IsRequired = true)]
      public string Address
      {
         get { return (string) base[AddressAttributeKey]; }
      }
   }
}