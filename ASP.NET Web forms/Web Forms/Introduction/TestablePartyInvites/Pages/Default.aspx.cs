using System;
using System.Web.ModelBinding;
using System.Web.UI;
using TestablePartyInvites.Models;
using TestablePartyInvites.Presenters;
using TestablePartyInvites.Presenters.Results;

namespace TestablePartyInvites.Pages
{
   public partial class Default : Page
   {
      [Ninject.Inject]
      public IPresenter<GuestResponse> Presenter { get; set; }

      /*private readonly IPresenter<GuestResponse> _presenter = new RsvpPresenter { Repository = new MemoryRepository() };

      public IPresenter<GuestResponse> Presenter
      {
         get { return _presenter; }
      }*/

      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            GuestResponse response = ((DataResult<GuestResponse>)Presenter.GetResult()).DataItem;
            if (TryUpdateModel(response, new FormValueProvider(ModelBindingExecutionContext)))
            {
               Response.Redirect(((RedirectResult)Presenter.GetResult(response)).Url);
            }
         }
      }
   }
}