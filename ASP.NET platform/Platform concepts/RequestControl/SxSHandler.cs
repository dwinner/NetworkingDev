using System.IO;
using System.Web;

namespace RequestControl
{
   public class SxSHandler : IHttpHandler
   {
      public bool IsReusable
      {
         get { return false; }
      }

      public void ProcessRequest(HttpContext context)
      {
         string requestFilePath = context.Request.FilePath;
         requestFilePath = requestFilePath.Substring(0, requestFilePath.LastIndexOf('.'));

         using (var htmlResponseWriter = new StringWriter())
         using (var sourceResponseWriter = new StringWriter())
         {
            context.Server.Execute(requestFilePath, htmlResponseWriter);
            context.Server.Execute(new SourceViewHandler(), sourceResponseWriter, true);
            context.Items["htmlResponse"] = htmlResponseWriter.ToString();
            context.Items["sourceResponse"] = sourceResponseWriter.ToString();
            context.Server.Execute("/SxSView.aspx");
            context.ApplicationInstance.CompleteRequest();
         }
      }
   }
}