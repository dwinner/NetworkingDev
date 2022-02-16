using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientSide.Validation.Controls
{
   /// <summary>
   ///    Элемент управления, который привязывает атрибуты ненавязчивой проверки достоверности
   ///    к свойствам класса модели
   /// </summary>
   public class ValidationRepeater : DataBoundControl, INamingContainer
   {
      [TemplateContainer(typeof(ValidationRepeaterTemplateItem))]
      public ITemplate PropertyTemplate { get; set; }

      public string Properties { get; set; }
      public string ModelType { get; set; }

      private static bool IsAttributeDefined(Type attributeType, Type targetType, string propertyName)
      {
         return Attribute.IsDefined(targetType.GetProperty(propertyName), attributeType);
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         var targetType = Type.GetType(ModelType);
         Debug.Assert(targetType != null, "targetType!= null");

         var propertyNames = Properties.Split(',');
         foreach (var propertyName in propertyNames)
         {
            var property = propertyName.Trim();
            var valAttributes = new Dictionary<string, object> { { "data-val", "true" } };

            if (Context.Request.Form[property] != null)
            {
               valAttributes.Add("value", Context.Request.Form[property]);
            }

            if (IsAttributeDefined(typeof(RequiredAttribute), targetType, property))
            {
               valAttributes.Add("data-val-required", string.Format("Provide a value for {0}", property));
            }

            if (IsAttributeDefined(typeof(StringLengthAttribute), targetType, property))
            {
               var strLenAttr =
                  targetType.GetProperty(property)
                     .GetCustomAttributes(typeof(StringLengthAttribute), false)
                     .Cast<StringLengthAttribute>()
                     .FirstOrDefault();
               if (strLenAttr != null)
               {
                  valAttributes.Add("data-val-length",
                     strLenAttr.ErrorMessage ??
                     string.Format("{0} must be {1}-{2} characters", property, strLenAttr.MinimumLength,
                        strLenAttr.MaximumLength));
                  valAttributes.Add("data-val-length-min", strLenAttr.MinimumLength);
                  valAttributes.Add("data-val-length-max", strLenAttr.MaximumLength);
               }
            }

            if (IsAttributeDefined(typeof(RangeAttribute), targetType, property))
            {
               var rangeAttribute =
                  targetType.GetProperty(property)
                     .GetCustomAttributes(typeof(RangeAttribute), false)
                     .Cast<RangeAttribute>()
                     .FirstOrDefault();
               if (rangeAttribute != null)
               {
                  valAttributes.Add("data-val-range",
                     rangeAttribute.ErrorMessage ??
                     string.Format("{0} must be {1}-{2} ", property, rangeAttribute.Minimum, rangeAttribute.Maximum));
                  valAttributes.Add("data-val-range-min", rangeAttribute.Minimum);
                  valAttributes.Add("data-val-range-max", rangeAttribute.Maximum);
               }
            }

            var templateItem = new ValidationRepeaterTemplateItem
            {
               DataItem = new ValidationRepeaterDataItem
               {
                  PropertyName = property,
                  ValidationAttributes =
                     string.Join(" ",
                        valAttributes.Keys.Select(key => string.Format("{0}='{1}'", key, valAttributes[key])).ToArray())
               }
            };

            PropertyTemplate.InstantiateIn(templateItem);
            templateItem.DataBind();
            templateItem.RenderControl(writer);
         }
      }
   }

   public class ValidationRepeaterDataItem
   {
      public string PropertyName { get; set; }
      public string ValidationAttributes { get; set; }
   }

   public class ValidationRepeaterTemplateItem : Control, IDataItemContainer
   {
      public object DataItem { get; set; }
      public int DataItemIndex { get; set; }
      public int DisplayIndex { get; set; }
   }
}