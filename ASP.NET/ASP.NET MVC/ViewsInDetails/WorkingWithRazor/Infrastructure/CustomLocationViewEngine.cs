using System.Web.Mvc;

namespace WorkingWithRazor.Infrastructure
{
   /// <summary>
   ///    Собственное местоположение для поиска представлений
   /// </summary>
   public class CustomLocationViewEngine : RazorViewEngine
   {
      public CustomLocationViewEngine()
      {
         ViewLocationFormats = new[] { "~/Views/{1}/{0}.cshtml", "~/Views/Common/{0}.cshtml" };
      }
   }
}