using System;
using System.Web.UI;

namespace Mobile.ViaWebForms
{
   public partial class Simple : Page
   {
      protected void Page_PreInit(object sender, EventArgs e)
      {
         MasterPageFile = Request.Browser.IsMobileDevice ? "Site.Mobile.Master" : "Site.Master";
      }
   }
}