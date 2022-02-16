using System;
using System.Collections.Generic;
using System.Web.UI;
using Controls.ControlTypes;

namespace Controls.Custom
{
   public partial class BasicCalc : UserControl
   {
      public int Initial { protected get; set; }
      public List<Calculation> Calculations { get; set; } = new List<Calculation>();
      public List<Calculation> GetCalculations() => Calculations;

      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request.HttpMethod == "POST")
         {
            var total = int.Parse(GetFormValue("initialVal"));
            var numbers = GetFormValue("calcValue").Split(',');
            var operations = GetFormValue("calcOp").Split(',');
            for (var i = 0; i < operations.Length; i++)
            {
               var val = int.Parse(numbers[i]);
               total += operations[i] == "Plus" ? val : 0 - val;
            }

            result.InnerText = total.ToString();
         }
      }

      private string GetFormValue(string name)
      {
         return Request.Form[GetId(name)];
      }

      protected string GetId(string name)
      {
         return string.Format("{0}{1}{2}", ClientID, ClientIDSeparator, name);
      }
   }
}