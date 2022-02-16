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
   public partial class Listings : Page
   {
      private readonly SportsStoreRepository _sportsStoreRepository = new SportsStoreRepository();
      private readonly int _pageSize = Properties.Settings.Default.PageSize;
      private const int DefaultPageValue = 1;

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            return;
         }

         int selectedProductId;
         if (!int.TryParse(Request.Form["add"], out selectedProductId))
         {
            return;
         }

         Product selectedProduct =
            _sportsStoreRepository.Products.FirstOrDefault(product => product.ProductId == selectedProductId);
         if (selectedProduct == null)
         {
            return;
         }

         SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
         SessionHelper.Set(Session, SessionKey.ReturnUrl, Request.RawUrl);
         // ReSharper disable once AssignNullToNotNullAttribute
         var virtualPathData = RouteTable.Routes.GetVirtualPath(null, "cart", null);
         if (virtualPathData != null)
         {
            Response.Redirect(virtualPathData.VirtualPath);
         }
      }

      public IEnumerable<Product> GetProducts()
      {
         return FilterProducts().OrderBy(product => product.ProductId)
            .Skip((CurrentPage - 1) * _pageSize)
            .Take(_pageSize);
      }

      private IEnumerable<Product> FilterProducts()
      {
         IEnumerable<Product> products = _sportsStoreRepository.Products;
         string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
         return currentCategory == null ? products : products.Where(product => product.Category == currentCategory);
      }

      public int CurrentPage
      {
         get
         {
            int page = GetPageFromRequest();
            return page > MaxPage ? MaxPage : page;
         }
      }

      private int GetPageFromRequest()
      {
         int page;
         var requestValue = (string)(RouteData.Values["page"] ?? Request.QueryString["page"]);
         return requestValue != null && int.TryParse(requestValue, out page) ? page : DefaultPageValue;
      }

      public int MaxPage
      {
         get
         {
            int productCount = FilterProducts().Count();
            return (int)Math.Ceiling((decimal)productCount / _pageSize);
         }
      }
   }
}