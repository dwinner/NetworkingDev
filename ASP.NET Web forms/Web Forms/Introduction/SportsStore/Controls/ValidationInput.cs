using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Controls
{
   /// <summary>
   /// Серверный элемент управления для согласованной проверки достоверности
   /// на серверной и клиентской стороне
   /// </summary>
   public class ValidationInput : WebControl
   {
      private string _namespace = "SportsStore.Models";
      private string _model = "Order";

      public string Namespace
      {
         get { return _namespace; }
         set { _namespace = value; }
      }

      public string Model
      {
         get { return _model; }
         set { _model = value; }
      }

      public string Property { get; set; }

      protected override void RenderContents(HtmlTextWriter output)
      {
         output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
         output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());

         Type modelType = Type.GetType(string.Format("{0}.{1}", Namespace, Model));
         if (modelType != null)
         {
            PropertyInfo propertyInfo = modelType.GetProperty(Property);
            var reqAttr = propertyInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (reqAttr != null)
            {
               output.AddAttribute("data-val", "true");
               output.AddAttribute("data-val-required", reqAttr.ErrorMessage);
            }

            output.RenderBeginTag("input");
            output.RenderEndTag();
         }
      }
   }
}
