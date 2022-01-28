using System.Configuration;

namespace ConfigFiles.CustomCollSections
{
   public class Place : ConfigurationElement
   {
      [ConfigurationProperty(PlaceStrings.Code, IsRequired = true)]
      public string Code
      {
         get { return (string) this[PlaceStrings.Code]; }
         set { this[PlaceStrings.Code] = value; }
      }

      [ConfigurationProperty(PlaceStrings.City, IsRequired = true)]
      public string City
      {
         get { return (string) this[PlaceStrings.City]; }
         set { this[PlaceStrings.City] = value; }
      }

      [ConfigurationProperty(PlaceStrings.Country, IsRequired = true)]
      public string Country
      {
         get { return (string) this[PlaceStrings.Country]; }
         set { this[PlaceStrings.Country] = value; }
      }

      private static class PlaceStrings
      {
         internal const string Code = "code";
         internal const string City = "city";
         internal const string Country = "country";
      }
   }
}