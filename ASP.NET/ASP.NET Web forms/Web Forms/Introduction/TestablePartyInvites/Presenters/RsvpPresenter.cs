using System.Collections.Generic;
using TestablePartyInvites.Models;
using TestablePartyInvites.Models.Repository;
using TestablePartyInvites.Presenters.Results;

namespace TestablePartyInvites.Presenters
{
   /// <summary>
   /// Бизнес-логика получения результата
   /// </summary>
   public class RsvpPresenter : IPresenter<GuestResponse>, IPresenter<IEnumerable<GuestResponse>>
   {
      [Ninject.Inject]
      public IRepository Repository { get; set; }

      #region Члены IPresenter<GuestResponse>

      IResult IPresenter<GuestResponse>.GetResult()
      {
         return new DataResult<GuestResponse>(new GuestResponse());
      }

      IResult IPresenter<GuestResponse>.GetResult(GuestResponse requestData)
      {
         Repository.AddResponse(requestData);
         return requestData.WillAttend != null && requestData.WillAttend.Value
            ? new RedirectResult("/Content/seeyouthere.html")
            : new RedirectResult("/Content/sorryyoucantcome.html");
      }

      #endregion

      #region Члены IPresenter<IEnumerable<GuestResponse>>

      IResult IPresenter<IEnumerable<GuestResponse>>.GetResult()
      {
         return new DataResult<IEnumerable<GuestResponse>>(Repository.GetAllResponses());
      }

      IResult IPresenter<IEnumerable<GuestResponse>>.GetResult(IEnumerable<GuestResponse> requestData)
      {
         throw new System.NotImplementedException();
      }

      #endregion
   }
}