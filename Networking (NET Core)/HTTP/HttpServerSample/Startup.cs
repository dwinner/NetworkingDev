using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpServerSample
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddScoped<GenerateHtml>();
         services.AddSingleton<Formula1>();
      }

      public void Configure(IApplicationBuilder app,
         IWebHostEnvironment env,
         GenerateHtml generateHtml,
         Formula1 formula1)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseRouting();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapGet("/api/racers",
               context => context.Response.WriteAsJsonAsync(formula1.GetChampions()));
            endpoints.MapGet("/api/racersdelay", async context =>
            {
               await Task.Delay(3000);
               await context.Response.WriteAsJsonAsync(formula1.GetChampions())
                  .ConfigureAwait(false);
            });
            endpoints.MapGet("/", context =>
            {
               string content = generateHtml.GetHtmlContent(context.Request);
               context.Response.ContentType = "text/html";
               return context.Response.WriteAsync(content);
            });
         });
      }
   }
}