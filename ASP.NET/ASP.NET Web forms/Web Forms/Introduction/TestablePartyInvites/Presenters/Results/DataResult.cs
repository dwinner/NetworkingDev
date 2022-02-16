namespace TestablePartyInvites.Presenters.Results
{
   public class DataResult<T> : IResult
   {
      private readonly T _dataItem;

      public T DataItem
      {
         get { return _dataItem; }
      }

      public DataResult(T dataItem)
      {
         _dataItem = dataItem;
      }
   }
}