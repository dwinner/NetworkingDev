using System.Collections.Generic;
using System.Web.ModelBinding;
using System.Web.UI;

namespace Routing
{
   public partial class Loop : Page
   {
      private const int DefaultCount = 3;

      public IEnumerable<int> GetValues([RouteData("count")] int? count)
      {
         for (int i = 0; i < (count ?? DefaultCount); i++)
         {
            yield return i;
         }
      }
   }
}