using System;
using System.Configuration;

namespace ConfigFiles.CustomSections
{
   public class NewUserDefaultsSection : ConfigurationSection
   {
      [ConfigurationProperty(UserDefaultStrings.City, IsRequired = true)]
      [CallbackValidator(CallbackMethodName = "ValidateCity", Type = typeof(NewUserDefaultsSection))]
      public string City
      {
         get { return (string)this[UserDefaultStrings.City]; }
         set { this[UserDefaultStrings.City] = value; }
      }

      [ConfigurationProperty(UserDefaultStrings.Country, DefaultValue = "USA")]
      public string Country
      {
         get { return (string)this[UserDefaultStrings.Country]; }
         set { this[UserDefaultStrings.Country] = value; }
      }

      [ConfigurationProperty(UserDefaultStrings.Language)]
      public string Language
      {
         get { return (string)this[UserDefaultStrings.Language]; }
         set { this[UserDefaultStrings.Language] = value; }
      }

      [ConfigurationProperty(UserDefaultStrings.RegionCode)]
      [IntegerValidator(MaxValue = 5, MinValue = 0)]
      public int Region
      {
         get { return (int)this[UserDefaultStrings.RegionCode]; }
         set { this[UserDefaultStrings.RegionCode] = value; }
      }

      public static void ValidateCity(object candidateValue)   // Метод специальной проверки достоверности
      {
         var value = candidateValue as string;
         if (value != null && value.ToLower() == "paris")
         {
            throw new Exception("City cannot be Paris");
         }
      }

      private static class UserDefaultStrings
      {
         internal const string City = "city";
         internal const string Country = "country";
         internal const string Language = "language";
         internal const string RegionCode = "regionCode";
      }
   }
}