using System;
using System.Globalization;
using System.Web.UI;

namespace Routing
{
   public partial class Calc : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         string firstString, secondString, operationString;

         if (RouteData.Values.Count > 0)
         {
            if (RouteData.Values.ContainsKey("numbers"))
            {
               string[] elements = RouteData.Values["numbers"].ToString().Split('/');
               firstString = elements[0];
               secondString = elements[1];
            }
            else
            {
               firstString = RouteData.Values["first"].ToString();
               secondString = RouteData.Values["second"].ToString();
            }

            operationString = RouteData.Values["operation"].ToString();
         }
         else
         {
            firstString = Request["First"];
            secondString = Request["Second"];
            operationString = Request["Operation"];
         }

         if (firstString != null && secondString != null && operationString != null)
         {
            First.Value = firstString;
            Second.Value = secondString;
            Operation.Value = operationString;
            int firstNumber = int.Parse(firstString);
            int secondNumber = int.Parse(secondString);
            Result.InnerText =
               (operationString == "plus" ? firstNumber + secondNumber : firstNumber - secondNumber).ToString(
                  CultureInfo.InvariantCulture);
            ResultPlaceHolder.Visible = true;
         }
      }
   }
}