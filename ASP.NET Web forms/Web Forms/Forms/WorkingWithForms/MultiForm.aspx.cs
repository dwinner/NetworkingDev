using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace WorkingWithForms
{
   public partial class MultiForm : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request.HttpMethod == "POST")
         {
            var name = Request.Form["button"];
            result.InnerText = string.Format("The {0} is {1}", name, GetValue(name));
         }
      }

      private string GetValue(string name)
      {
         var formValue = Request.Form[name];
         if (formValue != null)
         {
            var control = FindControl(name);
            var inputText = control as HtmlInputText;
            if (inputText != null)
            {
               inputText.Value = formValue;
            }
         }

         return formValue;
      }
   }
}