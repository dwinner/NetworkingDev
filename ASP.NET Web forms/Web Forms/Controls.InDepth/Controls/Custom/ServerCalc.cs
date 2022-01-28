using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls.ControlTypes;

namespace Controls.Custom
{
   public class ServerCalc : WebControl
   {
      private const string InitialName = "initialVal";
      private const string CalcName = "calcValue";
      private const string CalcopName = "calcOp";
      private int? _total = 0;

      public ServerCalc()
      {
         Load += (sender, args) =>
         {
            if (Context.Request.HttpMethod == "POST")
            {
               _total = int.Parse(GetFormValue(InitialName));
               var numbers = GetFormValue(CalcName).Split(',');
               var operators = GetFormValue(CalcopName).Split(',');
               for (var i = 0; i < operators.Length; i++)
               {
                  var val = int.Parse(numbers[i]);
                  _total += operators[i] == "Plus" ? val : 0 - val;
                  Calculations[i].Value = val;
               }
            }
         };
      }

      public int Initial { private get; set; }
      // ReSharper disable CollectionNeverUpdated.Global
      public List<Calculation> Calculations { get; } = new List<Calculation>();
      // ReSharper restore CollectionNeverUpdated.Global

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.RenderBeginTag(HtmlTextWriterTag.Div);

         writer.AddAttribute(HtmlTextWriterAttribute.Name, GetId(InitialName));
         writer.AddAttribute(HtmlTextWriterAttribute.Value, Initial.ToString());
         writer.RenderBeginTag(HtmlTextWriterTag.Input);

         foreach (var calc in Calculations)
         {
            writer.Write(calc.Operation == OperationType.Plus ? " + " : " - ");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, GetId(CalcName));
            writer.AddAttribute(HtmlTextWriterAttribute.Value, calc.Value.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, GetId(CalcopName));
            writer.AddAttribute(HtmlTextWriterAttribute.Value, calc.Operation.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
         }

         writer.Write(" ");
         writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
         writer.RenderBeginTag(HtmlTextWriterTag.Button);
         writer.Write("=");
         writer.RenderEndTag();

         if (_total.HasValue)
         {
            writer.Write(" {0}", _total.Value);
         }

         writer.RenderEndTag();
      }

      private string GetFormValue(string name) => Context.Request.Form[GetId(name)];
      private string GetId(string name) => string.Format("{0}{1}{2}", ClientID, ClientIDSeparator, name);
   }
}