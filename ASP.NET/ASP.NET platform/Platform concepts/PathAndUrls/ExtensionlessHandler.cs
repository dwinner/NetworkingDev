using System.IO;
using System.Web;

namespace PathAndUrls
{
   /// <summary>
   ///    Обработчик путей без расширений
   /// </summary>
   public class ExtensionlessHandler : IHttpHandler
   {
      public void ProcessRequest(HttpContext context)
      {
         context.Response.Write("<p>Extensionless Handler</p>");
         string vPath = context.Request.Path;
         if (vPath == "/")
         {
            context.Server.Transfer("/Default.aspx");
         }
         else if (File.Exists(context.Request.MapPath(string.Format("{0}.aspx", vPath))))
         {
            context.Server.Transfer(string.Format("{0}.aspx", vPath));
         }
         else
         {
            context.ApplicationInstance.CompleteRequest();
         }
      }

      public bool IsReusable
      {
         get { return false; }
      }
   }
}