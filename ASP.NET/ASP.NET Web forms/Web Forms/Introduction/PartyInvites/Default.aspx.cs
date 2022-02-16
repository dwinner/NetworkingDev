using System;
using System.Web.ModelBinding;
using System.Web.UI;

namespace PartyInvites
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            return;
         }

         var guestResponse = new GuestResponse();
         if (TryUpdateModel(guestResponse, new FormValueProvider(ModelBindingExecutionContext)))
         {
            ResponseRepository.Instance.AddResponse(guestResponse);
            Response.Redirect(guestResponse.WillAttend.HasValue && guestResponse.WillAttend.Value
               ? "seeyouthere.html"
               : "sorryyoucantcome.html");
         }
      }
   }
}