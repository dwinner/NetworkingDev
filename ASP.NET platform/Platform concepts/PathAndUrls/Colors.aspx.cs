using System.Collections.Generic;
using System.Web.UI;
using Microsoft.AspNet.FriendlyUrls;

namespace PathAndUrls
{
   public partial class Colors : Page
   {
      public IEnumerable<string> GetColors()
      {
         return Request.GetFriendlyUrlSegments();
      }
   }
}