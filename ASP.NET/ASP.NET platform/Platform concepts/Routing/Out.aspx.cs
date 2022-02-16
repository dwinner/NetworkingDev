using System.Web.Routing;
using System.Web.UI;

namespace Routing
{
   public partial class Out : Page
   {
      protected string GenerateUrl()
      {
         return GetRouteUrl("calc",
            new RouteValueDictionary { { "first", "10" }, { "operation", "plus" }, { "second", "20" } });
      }
   }
}