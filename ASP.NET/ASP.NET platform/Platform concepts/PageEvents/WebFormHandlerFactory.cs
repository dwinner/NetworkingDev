using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace PageEvents
{
   public class WebFormHandlerFactory : IHttpHandlerFactory
   {
      public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
      {
         var page = BuildManager.CreateInstanceFromVirtualPath(context.Request.Path, typeof(Page)) as Page;
         context.Response.Write(
            string.Format(
               "<div style=\"padding=10px;background-color=lightgray;border=thin solid black\">Content from {0}</div>",
               context.Request.Path));

         return page;
      }

      public void ReleaseHandler(IHttpHandler handler)
      {
      }
   }
}