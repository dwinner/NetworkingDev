using System;
using System.Web.Routing;

namespace SportsStore.Pages.Admin
{
   public partial class Admin : System.Web.UI.MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {

      }

      public string OrdersUrl
      {
         get { return GenerateUrl("admin_orders"); }
      }

      public string ProductsUrl
      {
         get { return GenerateUrl("admin_products"); }
      }

      private string GenerateUrl(string routeName)
      {
         // ReSharper disable once AssignNullToNotNullAttribute
         var virtualPathData = RouteTable.Routes.GetVirtualPath(null, routeName, null);
         return virtualPathData != null ? virtualPathData.VirtualPath : string.Empty;         
      }
   }
}