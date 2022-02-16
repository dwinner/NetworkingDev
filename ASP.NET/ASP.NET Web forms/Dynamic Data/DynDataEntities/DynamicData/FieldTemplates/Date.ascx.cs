using System;
using System.Web.DynamicData;
using System.Web.UI;

namespace DynDataEntities.DynamicData.FieldTemplates
{
   public partial class Date : FieldTemplateUserControl
   {
      public override string FieldValueString
      {
         get
         {
            if (FieldValue == null)
            {
               return null;
            }

            var date = (DateTime) FieldValue;
            return date.ToLongDateString();
         }
      }

      public override Control DataControl
      {
         get { return Literal1; }
      }
   }
}