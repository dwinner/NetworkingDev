using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace KatanaIntro
{
   using AppFunc = Func<IDictionary<string, object>, Task>;

   //class Program
   //{
   //    static void Main(string[] args)
   //    {
   //        string uri = "http://localhost:8080";

   //        using (WebApp.Start<Startup>(uri))
   //        {
   //            Console.WriteLine("Started!");
   //            Console.ReadKey();
   //            Console.WriteLine("Stopping!");
   //        }
   //    }
   //}

   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.Use(async (environment, next) =>
         {
            Console.WriteLine("Requesting : " + environment.Request.Path);

            await next();

            Console.WriteLine("Response: " + environment.Response.StatusCode);
         });

         ConfigureWebApi(app);


         app.UseHelloWorld();
      }

      private void ConfigureWebApi(IAppBuilder app)
      {
         var config = new HttpConfiguration();
         config.Routes.MapHttpRoute(
            "DefaultApi",
            "api/{controller}/{id}",
            new { id = RouteParameter.Optional });

         app.UseWebApi(config);
      }
   }


   public static class AppBuilderExtenions
   {
      public static void UseHelloWorld(this IAppBuilder app)
      {
         app.Use<HelloWorldComponent>();
      }
   }


   public class HelloWorldComponent
   {
      private AppFunc _next;

      public HelloWorldComponent(AppFunc next)
      {
         _next = next;
      }

      public Task Invoke(IDictionary<string, object> environment)
      {
         var response = environment["owin.ResponseBody"] as Stream;
         using (var writer = new StreamWriter(response))
         {
            return writer.WriteAsync("Hello!!");
         }
      }
   }
}