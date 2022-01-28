using System;
using System.Web.UI;

namespace ErrorHandling
{
   public partial class NotFoundShared : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         requestedUrl.InnerText = Request["aspxerrorpath"] ?? Request.RawUrl;
         errorSrc.InnerText = Request["aspxerrorpath"] == null ? "IIS" : "ASP.NET";
      }
   }
}