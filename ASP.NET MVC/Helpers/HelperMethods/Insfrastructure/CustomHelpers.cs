using System.Collections.Generic;
using System.Web.Mvc;

namespace HelperMethods.Insfrastructure
{
   /// <summary>
   ///    Внешние вспомогательные методы
   /// </summary>
   public static class CustomHelpers
   {
      public static MvcHtmlString ListArrayItems(this HtmlHelper html, IEnumerable<string> list)
      {
         var tag = new TagBuilder("ul");
         foreach (var item in list)
         {
            var itemTag = new TagBuilder("li");
            itemTag.SetInnerText(item);
            tag.InnerHtml += itemTag.ToString();
         }

         return new MvcHtmlString(tag.ToString());
      }

      public static MvcHtmlString DisplayMessage(this HtmlHelper html, string message)
      {
         var result = string.Format("This is the message: <p>{0}</p>", html.Encode(message));
         return new MvcHtmlString(result);
      }
   }
}