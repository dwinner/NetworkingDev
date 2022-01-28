using System.Web.Routing;
using System.Web.UI;

namespace Routing.Store
{
   public partial class Cart : Page
   {
      protected string GetUrlFromRoute()
      {
         var myRoute = RouteData.Route as Route;
         return myRoute != null ? myRoute.Url : "Unknown RouteBase";
      }
   }
}