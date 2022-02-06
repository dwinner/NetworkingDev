using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebSampleApp.Extensions;
using WebSampleApp.Middleware;
using WebSampleApp.Services;

namespace WebSampleApp
{
   public class Startup
   {
      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddScoped<SessionSample>();
         services.AddDistributedMemoryCache();
         services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));
         services.AddScoped<RequestAndResponseSamples>();
         services.AddSingleton<HealthSample>();
         services.AddHealthChecks()
            .AddCheck<CustomHealthCheck>("livecheck", HealthStatus.Unhealthy, new[] { "liveness" })
            .AddCheck<CustomReadyCheck>("readycheck", HealthStatus.Degraded, new[] { "readiness" });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RequestAndResponseSamples service,
         ILogger<Startup> logger)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.Use(next => context =>
         {
            context.Response.Headers.Add("CustomHeader1", "custom header value");
            return next(context);
         });

         app.UseStaticFiles();
         app.UseSession();
         app.UseHeaderMiddleware();
         app.UseRouting();
         app.UseEndpoints(endpoints =>
         {
            endpoints.MapHealthChecks("/health/allchecks");
            endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
            {
               Predicate = reg => reg.Tags.Contains("liveness"),
               ResultStatusCodes = new Dictionary<HealthStatus, int>
               {
                  [HealthStatus.Healthy] = StatusCodes.Status200OK,
                  [HealthStatus.Degraded] = StatusCodes.Status200OK,
                  [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
               }
            });
            endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
            {
               Predicate = reg => reg.Tags.Contains("readiness"),
               ResponseWriter = async (context, writer) =>
               {
                  context.Response.StatusCode = writer.Status switch
                  {
                     HealthStatus.Healthy => StatusCodes.Status200OK,
                     HealthStatus.Degraded => StatusCodes.Status503ServiceUnavailable,
                     HealthStatus.Unhealthy => StatusCodes.Status503ServiceUnavailable,
                     _ => StatusCodes.Status503ServiceUnavailable
                  };

                  if (writer.Status == HealthStatus.Healthy)
                  {
                     await context.Response.WriteAsync("ready").ConfigureAwait(false);
                  }
                  else
                  {
                     await context.Response.WriteAsync(writer.Status.ToString()).ConfigureAwait(false);
                     await context.Response.WriteAsync($"duration: {writer.TotalDuration}").ConfigureAwait(false);
                  }
               }
            });

            endpoints.Map("sethealthy", async context =>
            {
               var changeHealthService = context.RequestServices.GetRequiredService<HealthSample>();
               string healthyValue = context.Request.Query["healthy"];
               if (bool.TryParse(healthyValue, out var healthy))
               {
                  changeHealthService.SetHealthy(healthy);
               }
               else
               {
                  await context.Response.WriteAsync("Missing healthy query parameter").ConfigureAwait(false);
               }
            });

            endpoints.Map("/randr/{action?}", async context =>
            {
               var service = context.RequestServices.GetRequiredService<RequestAndResponseSamples>();
               var action = context.GetRouteValue("action")?.ToString();
               var method = context.Request.Method;
               var result = (action, method) switch
               {
                  (null, "GET") => RequestAndResponseSamples.GetRequestInformation(context.Request),
                  ("header", "GET") => RequestAndResponseSamples.GetHeaderInformation(context.Request),
                  ("add", "GET") => RequestAndResponseSamples.QueryParameters(context.Request),
                  ("content", "GET") => RequestAndResponseSamples.Content(context.Request),
                  ("form", "GET" or "POST") => RequestAndResponseSamples.Form(context.Request),
                  ("writecookie", "GET") => RequestAndResponseSamples.WriteCookie(context.Response),
                  ("readcookie", "GET") => RequestAndResponseSamples.ReadCookie(context.Request),
                  ("json", "GET") => RequestAndResponseSamples.GetJson(context.Response),
                  _ => string.Empty
               };

               if (action is "json")
               {
                  await context.Response.WriteAsync(result).ConfigureAwait(false);
               }
               else
               {
                  var doc = result.HtmlDocument("Request and Response Samples");
                  await context.Response.WriteAsync(doc).ConfigureAwait(false);
               }
            });

            endpoints.Map("/add/{x:int}/{y:int}", async context =>
            {
               var x = int.Parse(context.GetRouteValue("x")?.ToString() ?? "0");
               var y = int.Parse(context.GetRouteValue("y")?.ToString() ?? "0");
               await context.Response.WriteAsync($"The result of {x} + {y} is {x + y}").ConfigureAwait(false);
            });

            endpoints.Map("/session", async context =>
            {
               var service = context.RequestServices.GetRequiredService<SessionSample>();
               await service.SessionAsync(context).ConfigureAwait(false);
            });

            endpoints.MapGet("/", async context =>
            {
               string[] lines =
               {
                  @"<ul>",
                  @"<li><a href=""/hello.html"">Static Files</a> - requires UseStaticFiles</li>",
                  @"<li><a href=""/add/37/5"">Route Constraints</a></li>",
                  @"<li>Request and Response",
                  @"<ul>",
                  @"<li><a href=""/randr"">Request and Response</a></li>",
                  @"<li><a href=""/randr/header"">Header</a></li>",
                  @"<li><a href=""/randr/add?x=38&y=4"">Add</a></li>",
                  @"<li><a href=""/randr/content?data=sample"">Content</a></li>",
                  @"<li><a href=""/randr/content?data=<h1>Heading 1</h1>"">HTML Content</a></li>",
                  @"<li><a href=""/randr/content?data=<script>alert('hacker');</script>"">Bad Content</a></li>",
                  @"<li><a href=""/randr/encoded?data=<h1>sample</h1>"">Encoded content</a></li>",
                  @"<li><a href=""/randr/encoded?data=<script>alert('hacker');</script>"">Encoded bad Content</a></li>",
                  @"<li><a href=""/randr/form"">Form</a></li>",
                  @"<li><a href=""/randr/writecookie"">Write cookie</a></li>",
                  @"<li><a href=""/randr/readcookie"">Read cookie</a></li>",
                  @"<li><a href=""/randr/json"">JSON</a></li>",
                  @"</ul>",
                  @"</li>",
                  @"<li><a href=""/session"">Session</a></li>",
                  @"<li>Health check",
                  @"<ul>",
                  @"<li><a href=""/health/live"">live</a></li>",
                  @"<li><a href=""/health/ready"">ready</a></li>",
                  @"<li><a href=""/health/allchecks"">all checks</a></li>",
                  @"<li><a href=""/sethealthy?healthy=true"">set healthy</a></li>",
                  @"<li><a href=""/sethealthy?healthy=false"">set unhealthy</a></li>",
                  @"</ul>",
                  @"</li>",
                  @"</ul>"
               };

               StringBuilder sb = new();
               foreach (var line in lines)
               {
                  sb.Append(line);
               }

               var html = sb.ToString().HtmlDocument("Web Sample App");
               await context.Response.WriteAsync(html).ConfigureAwait(false);
               Debug.WriteLine(nameof(Configure));
            });
         });
      }
   }
}