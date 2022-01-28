using System;
using System.Web;
using System.Web.UI;

namespace WorkingWithForms
{
   public partial class Valid : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request.HttpMethod == "POST")
         {
            try
            {
               nameResult.InnerText = Request.Form["html"];
            }
            catch (HttpRequestValidationException)
            {
               nameResult.InnerText = "Dangerous data!";
            }

            // Использование непроверенных данных
            htmlResult.InnerText = Request.Unvalidated.Form["html"];
         }
      }
   }
}