using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using SportsStore.Models.Repository;

namespace SportsStore.Controls
{
   /// <summary>
   /// Элемент управления категориями товаров
   /// </summary>
   public partial class CategoryList : UserControl
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected string CreateHomeLinkHtml()
      {
         // ReSharper disable once AssignNullToNotNullAttribute
         var virtualPath = RouteTable.Routes.GetVirtualPath(null, null);
         string path = virtualPath != null ? virtualPath.VirtualPath : string.Empty;
         return string.Format("<a href='{0}'>Home</a>", path);
      }

      protected IEnumerable<string> GetCategories()
      {
         return new SportsStoreRepository().Products
            .Select(product => product.Category)
            .Distinct()
            .OrderBy(x => x);
      }

      protected string CreateLinkHtml(string category)
      {
         string selectedCategory = (string) Page.RouteData.Values["category"] ?? Request.QueryString["category"];
         var virtualPath = RouteTable.Routes.GetVirtualPath(null, null,
            new RouteValueDictionary
            {
               {"category", category},
               {"page", "1"}
            });
         string path = virtualPath != null ? virtualPath.VirtualPath : string.Empty;
         return string.Format("<a href='{0}' {1}>{2}</a>",
            path,
            category == selectedCategory ? "class='selected'" : string.Empty,
            category);
      }
   }
}