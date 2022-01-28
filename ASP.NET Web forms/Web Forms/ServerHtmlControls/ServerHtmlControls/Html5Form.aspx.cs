using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using static System.Diagnostics.Debug;

namespace ServerHtmlControls
{
   public partial class Html5Form : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var rangeInput = new HtmlInputGenericControl("range") {ID = "userVal2"};
         rangeInput.Attributes["step"] = "5";
         rangeInput.Attributes["min"] = "50";
         rangeInput.Attributes["max"] = "100";
         rangeInput.Attributes["step"] = "5";
         inputContainer.Controls.Add(rangeInput);

         if (IsPostBack)
         {
            WriteLine($"Value 1: {userVal.Value}");
            WriteLine($"Value 2: {Request["userVal2"]}");
         }
      }
   }
}