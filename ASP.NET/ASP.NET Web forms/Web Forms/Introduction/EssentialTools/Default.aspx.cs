using System;
using System.Web.ModelBinding;

namespace EssentialTools
{
   public partial class Default : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            var formData = new FormData();
            if (TryUpdateModel(formData, new FormValueProvider(ModelBindingExecutionContext)))
            {
               target.InnerText = string.Format("Name: {0}, City: {1}", formData.Name, formData.City);
            }
         }
      }
   }
}