using System.Web.UI;
using System.Web.UI.WebControls;

namespace Binding.Controls
{
   public class OperationSelector : WebControl
   {
      private readonly string[] _operators = { "Add", "Substract" };
      private string _selectedOperator;

      public OperationSelector()
      {
         Load += (sender, args) =>
         {
            if (Page.IsPostBack)
            {
               _selectedOperator = Context.Request[GetFormId("op")];
            }
         };
      }

      public string SelectedOperator
      {
         get { return _selectedOperator ?? _operators[0]; }
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.AddAttribute(HtmlTextWriterAttribute.Name, GetFormId("op"));
         writer.RenderBeginTag(HtmlTextWriterTag.Select);

         foreach (var op in _operators)
         {
            writer.AddAttribute(HtmlTextWriterAttribute.Value, op);
            if (op == SelectedOperator)
            {
               writer.AddAttribute(HtmlTextWriterAttribute.Selected, "selected");
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Option);
            writer.Write(op);
            writer.RenderEndTag();
         }

         writer.RenderEndTag();
      }

      private string GetFormId(string name)
      {
         return string.Format("{0}{1}{2}", ClientID, ClientIDSeparator, name);
      }
   }
}