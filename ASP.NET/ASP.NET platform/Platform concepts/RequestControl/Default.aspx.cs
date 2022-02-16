using System;
using System.Web.UI;

namespace RequestControl
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            string choise = Request.Form["choise"];
            switch (choise)
            {
               case "redirect302":  // Временное перенаправление
                  Response.Redirect("/SecondPage.aspx");
                  break;
               case "redirect301":  // Постоянное перенаправление
                  Response.RedirectPermanent("/CurrentTimeHandler.ashx");
                  break;
               case "handredirect": // Ручное перенаправление
                  Response.RedirectLocation = "/CurrentTimeHandler.ashx";
                  Response.StatusCode = 301;
                  Context.ApplicationInstance.CompleteRequest();
                  break;
               case "transferpage":
                  Server.Transfer("/SecondPage.aspx");
                  break;
            }
         }
      }
   }
}