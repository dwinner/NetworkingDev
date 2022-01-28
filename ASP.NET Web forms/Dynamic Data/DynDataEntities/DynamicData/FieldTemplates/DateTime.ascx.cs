using System.Web.UI;

namespace DynDataEntities
{
   public partial class DateTimeField : System.Web.DynamicData.FieldTemplateUserControl
   {
      public override Control DataControl
      {
         get
         {
            return Literal1;
         }
      }

   }
}
