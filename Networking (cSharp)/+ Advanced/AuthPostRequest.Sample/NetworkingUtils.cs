using System;
using System.Linq;

namespace AuthPostRequest.Sample
{
   public static class NetworkingUtils
   {
      public static string BuildPostData(params Tuple<string, string>[] postItems)
      {
         var rawPostData = postItems.Aggregate(string.Empty,
            (current, dataItem) => current + $"{dataItem.Item1}={dataItem.Item2}&");
         return rawPostData.Substring(0, rawPostData.Length - 1);
      }
   }
}