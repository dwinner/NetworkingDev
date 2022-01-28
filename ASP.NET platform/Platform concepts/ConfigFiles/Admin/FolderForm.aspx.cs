using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI;
using ConfigFiles.CustomCollSections;
using ConfigFiles.CustomSections;

namespace ConfigFiles.Admin
{
   public partial class FolderForm : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<string> GetConfig()
      {
         IEnumerable<string> appSettings =
            from object appSettingKey in WebConfigurationManager.AppSettings
            select
               string.Format("{0} = {1}", appSettingKey, WebConfigurationManager.AppSettings[appSettingKey.ToString()]);

         IEnumerable<string> customParams = GetCustomParams();

         return appSettings.Union(customParams);
      }

      private static IEnumerable<string> GetCustomParams()
      {
         var defaults = (NewUserDefaultsSection) WebConfigurationManager.GetSection("customDefaults/newUserDefaults");
         yield return
            string.Format("Defaults: {0}, {1}, {2}, {3}", defaults.City, defaults.Country, defaults.Language,
               defaults.Region);

         var places = (PlaceSection) WebConfigurationManager.GetSection("customDefaults/places");
         foreach (Place place in places.Places)
         {
            yield return string.Format("Place: {0}, {1}, {2}", place.Code, place.City, place.Country);
         }
      }
   }
}