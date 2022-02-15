using System;
using System.Web.UI;

namespace WebApi.Intro
{
   public partial class EventValidationDemo : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {         
         formValue.InnerText = Request.Form["nameSelect"];
      }
   }
}