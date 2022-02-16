using System;
using System.Globalization;
using System.Linq;
using System.Web.Routing;
using SportsStore.Models;
using SportsStore.Pages.Helpers;

namespace SportsStore.Controls
{
   public partial class CartSummary : System.Web.UI.UserControl
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Cart myCart = SessionHelper.GetCart(Session);
         csQuantity.InnerText = myCart.Lines.Sum(line => line.Quantity).ToString(CultureInfo.InvariantCulture);
         csTotal.InnerText = myCart.ComputeTotalValue().ToString("C");
         // ReSharper disable once AssignNullToNotNullAttribute
         var virtualPathData = RouteTable.Routes.GetVirtualPath(null, "cart", null);
         if (virtualPathData != null)
         {
            csLink.HRef = virtualPathData.VirtualPath;
         }
      }
   }
}