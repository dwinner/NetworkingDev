namespace TestablePartyInvites.Presenters.Results
{
   public class RedirectResult : IResult
   {
      private readonly string _url;

      public string Url
      {
         get { return _url; }
      }

      public RedirectResult(string url)
      {
         _url = url;
      }
   }
}