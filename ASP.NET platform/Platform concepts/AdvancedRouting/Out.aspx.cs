using System.Web.Routing;
using System.Web.UI;

namespace AdvancedRouting
{
   public partial class Out : Page
   {
      protected string GenerateUrl()
      {
         return GetRouteUrl(new RouteValueDictionary { { "first", "10" }, { "operation", "plus" }, { "second", "20" } });
      }
   }
}