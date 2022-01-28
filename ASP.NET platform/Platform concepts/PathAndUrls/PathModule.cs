using System.IO;
using System.Linq;
using System.Web;

namespace PathAndUrls
{
   /// <summary>
   ///    Модуль переписывания путей
   /// </summary>
   public class PathModule : IHttpModule
   {
      private static readonly string[] Extensions = { ".aspx", ".ashx" };

      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += (sender, args) => HandleRequest(httpApp);
      }

      public void Dispose()
      {
      }

      private static void HandleRequest(HttpApplication httpApp)
      {
         if (httpApp.Request.CurrentExecutionFilePathExtension != string.Empty)
            return;

         string target = null;
         string virtualPath = httpApp.Request.CurrentExecutionFilePath;
         if (virtualPath == "/")
         {
            target = "/Default.aspx";
         }
         else
         {
            foreach (
               var ext in
                  Extensions.Where(
                     ext => File.Exists(httpApp.Request.MapPath(string.Format("{0}{1}", virtualPath, ext)))))
            {
               target = string.Format("{0}{1}", virtualPath, ext);
               break;
            }
         }

         if (target != null)         
            httpApp.Context.RewritePath(target);         
      }
   }
}