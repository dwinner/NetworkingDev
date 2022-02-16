using System.Web.Mvc;

namespace ControllersAndActions.Infrastructure
{
   /// <summary>
   ///    Своя реализация действия по перенаправлению
   /// </summary>
   public class CustomRedirectResult : ActionResult
   {
      public string Url { get; set; }

      public override void ExecuteResult(ControllerContext context)
      {
         var fullUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
         context.HttpContext.Response.Redirect(fullUrl);
      }
   }
}