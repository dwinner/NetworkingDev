using System.Web;

namespace Routing
{
   public class RouteTestModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += (sender, args) =>
         {
            httpApp.Context.Items["routePath"] = httpApp.Request.CurrentExecutionFilePath;
            httpApp.Server.Execute("/RouteTest.aspx");
         };
      }

      public void Dispose()
      {
      }
   }
}