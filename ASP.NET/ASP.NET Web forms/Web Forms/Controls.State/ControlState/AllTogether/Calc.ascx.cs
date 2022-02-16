using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ControlState.AllTogether
{
   public partial class Calc : UserControl
   {
      private List<string> _history = new List<string>();

      protected void Page_Init(object sender, EventArgs args)
      {
         Page.RegisterRequiresControlState(this);
      }

      protected override void LoadControlState(object savedState)
      {
         _history = savedState as List<string> ?? new List<string>();
      }

      protected override object SaveControlState()
      {
         return _history.Count > 3 ? _history.GetRange(0, 3) : _history;
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            var result = int.Parse(FirstValue.Value) + int.Parse(SecondValue.Value);
            ResultValue.InnerText = result.ToString();
            _history.Insert(0, $"{FirstValue.Value} + {SecondValue.Value} = {result}");
         }
      }

      public IEnumerable<string> GetHistory() => _history;
   }
}