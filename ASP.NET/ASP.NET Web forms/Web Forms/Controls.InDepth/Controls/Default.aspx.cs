using System;
using System.Web.UI;

namespace Controls
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request.HttpMethod == "POST")
         {
            var firstVal = int.Parse(Request.Form["firstNumber"]);
            var secondVal = int.Parse(Request.Form["secondNumber"]);
            result.InnerText = (firstVal + secondVal).ToString();
         }
      }
   }
}