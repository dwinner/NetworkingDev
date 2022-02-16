using System;
using System.Text;
using System.Web.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.HtmlHelpers
{
   public static class PagingHelpers
   {
      public static MvcHtmlString PageLinks(PagingInfo pagingInfo, Func<int, string> pageUrl)
      {
         var result = new StringBuilder();
         for (var i = 1; i <= pagingInfo.TotalPages; i++)
         {
            var tag = new TagBuilder("a") { InnerHtml = i.ToString() };
            tag.MergeAttribute("href", pageUrl(i));
            if (i == pagingInfo.CurrentPage)
            {
               tag.AddCssClass("selected");
               tag.AddCssClass("btn-primary");
            }
            tag.AddCssClass("btn btn-default");
            result.Append(tag);
         }

         return MvcHtmlString.Create(result.ToString());
      }
   }
}