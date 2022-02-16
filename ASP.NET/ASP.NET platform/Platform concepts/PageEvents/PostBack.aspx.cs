using System;
using System.Globalization;
using System.Web.UI;

namespace PageEvents
{
   public partial class PostBack : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         FirstPlaceHolder.Visible = !(SecondPlaceHolder.Visible = IsPostBack);
         if (IsPostBack)
         {
            int firstNumber, secondNumber;
            if (int.TryParse(FirstNumber.Value, out firstNumber) && int.TryParse(SecondNumber.Value, out secondNumber))
            {
               Result.InnerText = (firstNumber + secondNumber).ToString(CultureInfo.InvariantCulture);
            }
         }
      }
   }
}