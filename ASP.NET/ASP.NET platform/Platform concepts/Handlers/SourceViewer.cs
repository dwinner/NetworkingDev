/**
 * Пример переопределения стандартных фабрик обработчиков
 */

using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace Handlers
{
   public class SourceViewer : PageHandlerFactory
   {
      public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
      {
         if (context != null)
         {
            string sourceQstr = (context.Request.QueryString["source"] ?? string.Empty).ToLower();
            return sourceQstr == "true"
               ? new SourceViewHandler()
               : base.GetHandler(context, requestType, virtualPath, path);
         }

         throw new InvalidOperationException("Handler not found");
      }

      public override void ReleaseHandler(IHttpHandler handler)
      {
         if (!(handler is SourceViewHandler))
         {
            base.ReleaseHandler(handler);
         }
      }

      private class SourceViewHandler : IHttpHandler
      {
         public void ProcessRequest(HttpContext context)
         {
            HttpResponse response = context.Response;            
            HttpRequest request = context.Request;
            string virtualPath = request.FilePath;

            response.ContentType = "text/html";
            response.Write(string.Format("<h3>Contents of {0}</h3>", virtualPath));
            response.Write("<pre>");
            using (var reader = new StreamReader(request.MapPath(virtualPath)))
            {
               response.Write(context.Server.HtmlEncode(reader.ReadToEnd()));
            }
            response.Write("</pre>");
         }

         public bool IsReusable
         {
            get { return false; }
         }
      }
   }
}