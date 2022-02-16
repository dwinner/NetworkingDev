using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;

namespace Routing
{
   public partial class RouteTest : Page
   {
      public IEnumerable<RouteMatchInfo> GetRouteMatches()
      {
         HttpContextBase contextBase = new ContextMapper((string)Context.Items["routePath"], Request);
         foreach (RouteBase route in RouteTable.Routes.Where(route => route != null))
         {
            RouteData rData = route.GetRouteData(contextBase);
            if (rData != null)
            {
               var builder = new StringBuilder();
               foreach (var key in rData.Values.Keys)
               {
                  builder.AppendFormat("{0} = {1},", key, rData.Values[key]);
               }

               yield return new RouteMatchInfo
               {
                  Matches = true,
                  Path = route is Route ? ((Route)route).Url : route.GetType().ToString(),
                  Values = builder.ToString()
               };
            }
            else
            {
               yield return new RouteMatchInfo
               {
                  Matches = false,
                  Path = route is Route ? ((Route)route).Url : route.GetType().ToString(),
                  Values = "-"
               };
            }
         }
      }
   }
}