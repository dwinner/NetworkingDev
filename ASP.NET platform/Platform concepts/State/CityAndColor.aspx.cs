using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web.UI;

namespace State
{
   public partial class CityAndColor : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
// ReSharper disable SuspiciousTypeConversion.Global
         if (IsPostBack && this is IRequiresSessionState)
// ReSharper restore SuspiciousTypeConversion.Global
         {
            Session["color"] = Enum.Parse(typeof (Color), ColorList.SelectedValue);
            Session["city"] = Enum.Parse(typeof (City), CityList.SelectedValue);
         }
         
// ReSharper disable SuspiciousTypeConversion.Global
         if (this is IReadOnlySessionState || this is IRequiresSessionState)
// ReSharper restore SuspiciousTypeConversion.Global
         {
            ColorList.Enabled = CityList.Enabled = true;
            ColorList.SelectedValue = Session["color"].ToString();
            CityList.SelectedValue = Session["city"].ToString();
         }
         else
         {
            ColorList.Enabled = CityList.Enabled = false;
         }
      }

      public static IEnumerable<string> GetColors()
      {
         return Enum.GetNames(typeof (Color));
      }

      public static IEnumerable<string> GetCities()
      {
         return Enum.GetNames(typeof (City));
      }
   }
}