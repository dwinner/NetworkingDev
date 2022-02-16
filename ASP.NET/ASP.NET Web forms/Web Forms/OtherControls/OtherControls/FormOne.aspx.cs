using System.Web.UI;

namespace OtherControls
{
   public partial class FormOne : Page
   {
      public string Name
      {
         get { return nameValue.Value; }
      }
   }
}