using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using SelfHosted.Srv.EndPoints;

[assembly: OwinStartup(typeof(SelfHosted.Srv.Startup))]

namespace SelfHosted.Srv
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR<SamplePersistentConnection>("/SamplePC");
         app.Run(context =>
         {
            if (context.Request.Path.Value.Equals("/", StringComparison.CurrentCultureIgnoreCase))
            {
               context.Response.ContentType = "text/html";
               var result = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "index.html"));

               return context.Response.WriteAsync(result);
            }

            if (context.Request.Path.Value.StartsWith("/scripts/", StringComparison.CurrentCultureIgnoreCase))
            {
               context.Response.ContentType = "text/javascript";
               var result = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, context.Request.Path.Value));

               return context.Response.WriteAsync(result);
            }
            
            return Task.FromResult<object>(null);
         });
      }
   }
}
