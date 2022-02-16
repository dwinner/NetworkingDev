using System.Configuration;
using ConfigFiles.CustomCollSections;
using ConfigFiles.CustomSections;

namespace ConfigFiles
{
   public class UserAndPlaceSectionGroup : ConfigurationSectionGroup
   {
      private const string NewuserdefaultsNodeName = "newUserDefaults";
      private const string PlacesNodeName = "places";

      [ConfigurationProperty(NewuserdefaultsNodeName)]
      public NewUserDefaultsSection NewUserDefaults
      {
         get { return (NewUserDefaultsSection)Sections[NewuserdefaultsNodeName]; }
      }

      [ConfigurationProperty(PlacesNodeName)]
      public PlaceSection Places
      {
         get { return (PlaceSection)Sections[PlacesNodeName]; }
      }
   }
}