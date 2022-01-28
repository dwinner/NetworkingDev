using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
   public partial class CartView : Page
   {
      private readonly SportsStoreRepository _sportsStoreRepository = new SportsStoreRepository();

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            return;
         }

         int productId;
         if (!int.TryParse(Request.Form["remove"], out productId))
         {
            return;
         }

         Product productToRemove = _sportsStoreRepository.Products.FirstOrDefault(product => product.ProductId == productId);
         if (productToRemove != null)
         {
            SessionHelper.GetCart(Session).RemoveLine(productToRemove);
         }
      }

      public IEnumerable<CartLine> GetCartLines()
      {
         return SessionHelper.GetCart(Session).Lines;
      }

      public decimal CartTotal
      {
         get { return SessionHelper.GetCart(Session).ComputeTotalValue(); }
      }

      public string ReturnUrl
      {
         get { return SessionHelper.Get<string>(Session, SessionKey.ReturnUrl); }
      }

      public string CheckoutUrl
      {
         get
         {
            // ReSharper disable once AssignNullToNotNullAttribute
            var virtualPathData = RouteTable.Routes.GetVirtualPath(null, "checkout", null);
            return virtualPathData != null ? virtualPathData.VirtualPath : string.Empty;
         }
      }
   }
}