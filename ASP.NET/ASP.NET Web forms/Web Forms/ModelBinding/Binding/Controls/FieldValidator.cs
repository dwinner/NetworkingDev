using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Binding.Controls
{
   /// <summary>
   ///    Элемент управления для ошибок на уровне полей
   /// </summary>
   public class FieldValidator : WebControl
   {
      public string PropertyName { get; set; }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         ModelState modelState;
         if (PropertyName != null && !Page.ModelState.IsValid && (modelState = Page.ModelState[PropertyName]) != null &&
             modelState.Errors != null && modelState.Errors.Count > 0)
         {
            if (CssClass != null)
            {
               writer.AddAttribute("class", CssClass);
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.Write("*");
            writer.RenderEndTag();
         }
      }
   }
}