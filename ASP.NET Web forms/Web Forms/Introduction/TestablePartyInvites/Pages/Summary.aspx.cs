using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestablePartyInvites.Models;
using TestablePartyInvites.Presenters;
using TestablePartyInvites.Presenters.Results;

namespace TestablePartyInvites.Pages
{
   public partial class Summary : System.Web.UI.Page
   {
      private IEnumerable<GuestResponse> _data;

      [Ninject.Inject]
      public IPresenter<IEnumerable<GuestResponse>> Presenter { get; set; }

      protected void Page_Load(object sender, EventArgs e)
      {
         _data = ((DataResult<IEnumerable<GuestResponse>>)Presenter.GetResult()).DataItem;
      }

      protected string GetResponses(bool accepted)
      {
         var html = new StringBuilder();
         IEnumerable<GuestResponse> selectedData =
            _data.Where(response => response.WillAttend.HasValue && response.WillAttend.Value == accepted);
         foreach (var rsvp in selectedData)
         {
            html.Append(string.Format("<tr><td>{0}</td><td>{1}<td><td>{2}</td>", rsvp.Name, rsvp.Email, rsvp.Phone));
         }

         return html.ToString();
      }
   }
}