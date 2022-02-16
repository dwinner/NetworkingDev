using System.Diagnostics;
using System.Web;

namespace PathAndUrls
{
   public class SimpleModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += (sender, args) => ProcessRequest(httpApp);
      }

      public void Dispose()
      {
      }

      private static void ProcessRequest(HttpApplication httpApp)
      {
         //if (httpApp.Request.FilePath == "/Test.aspx")
         //   httpApp.Server.Transfer("/Content/RequestReporter.aspx");

         // Переписывание путей
         if (httpApp.Request.Path == "/accounts")
         {
            int functionValue;
            httpApp.Context.RewritePath(int.TryParse(httpApp.Request.Form["function"], out functionValue)
               ? "/Default.aspx"
               : "/Content/RequestReporter.aspx");
         }

         WriteMsg("URL Requested: {0} {1}", httpApp.Request.RawUrl, httpApp.Request.FilePath);
      }

      private static void WriteMsg(string formatString, params object[] vals)
      {
         Debug.WriteLine(formatString, vals);
      }
   }
}