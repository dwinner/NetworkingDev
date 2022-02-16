using System;
using System.Collections.Generic;
using System.Web.UI;
using Controls.ControlTypes;
using Controls.Custom;

namespace Controls
{
   public partial class Loader : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var calc = (BasicCalc) LoadControl("~/Custom/BasicCalc.ascx");
         calc.Initial = 500;
         var calculations = new List<Calculation>
         {
            new Calculation {Value = 90, Operation = OperationType.Plus},
            new Calculation {Value = 50, Operation = OperationType.Minus}
         };
         calc.Calculations = calculations;
         controlTarget.Controls.Add(calc);
      }
   }
}