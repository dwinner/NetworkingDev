using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI;
using ConfigFiles.CustomCollSections;

namespace ConfigFiles
{
   public partial class SelectCity : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<Place> GetPlaces()
      {
         return
            ((PlaceSection) WebConfigurationManager.GetWebApplicationSection("customDefaults/places")).Places
               .Cast<Place>();
      }
   }
}