using System.Collections.Generic;
using System.Web.UI;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;

namespace PathAndUrls
{
   public partial class Count : Page
   {
      private const int DefaultMaxNumber = 5;      

      public IEnumerable<int> GetNumbers([FriendlyUrlSegments(0)] int? max)
      {
         for (int i = 0; i < (max ?? DefaultMaxNumber); i++)
         {
            yield return i;
         }
      }
   }
}