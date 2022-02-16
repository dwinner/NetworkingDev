using System.Web;

namespace AdvancedRouting
{
   public class CustomHandler : IHttpHandler
   {
      public bool FactoryCreated { private get; set; }

      public void ProcessRequest(HttpContext context)
      {
         context.Response.ContentType = "text/plain";
         context.Response.Write("This is the custom handler");
         context.Response.Write(FactoryCreated ? " (Created via the Factory)" : " (Created directly)");
      }

      public bool IsReusable
      {
         get { return false; }
      }
   }

   public class CustomHandlerFactory : IHttpHandlerFactory
   {
      public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
      {
         return new CustomHandler { FactoryCreated = true };
      }

      public void ReleaseHandler(IHttpHandler handler)
      {
      }
   }
}