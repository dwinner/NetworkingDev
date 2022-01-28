using TestablePartyInvites.Presenters.Results;

namespace TestablePartyInvites.Presenters
{
   public interface IPresenter<in T>
   {
      IResult GetResult();

      IResult GetResult(T requestData);
   }
}