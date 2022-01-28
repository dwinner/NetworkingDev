/**
 * Simple HTTP server
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Server;
using static System.Console;

namespace SimpleHttpServerSample
{
   internal static class HttpServerEntry
   {
      private const string HtmlFormat =
         "<!DOCTYPE html><html><head><title>{0}</title></head>" + "<body>{1}</body></html>";

      private static void Main(string[] args)
      {
         if (args.Length < 1)
         {
            ShowUsage();
            return;
         }

         StartServerAsync(args).Wait();
         ReadLine();
      }

      private static async Task StartServerAsync(params string[] prefixes)
      {
         try
         {
            WriteLine("server starting at");
            var listener = new WebListener(new WebListenerSettings {RequestQueueLimit = 10});
            foreach (var prefix in prefixes)
            {
               listener.Settings.UrlPrefixes.Add(prefix);
               WriteLine($"\t{prefix}");
            }

            listener.Start();

            do
            {
               using (var context = await listener.AcceptAsync().ConfigureAwait(false))
               {
                  context.Response.Headers.Add("content-type", new[] {"text/html"});
                  context.Response.StatusCode = (int) HttpStatusCode.OK;

                  var buffer = GetHtmlContent(context.Request);
                  await context.Response.Body.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
               }
            }
            while (true);
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }
      }

      private static void ShowUsage()
         => WriteLine("Usage: HttpServer Prefix [Prefix2] [Prefix3] [Prefix4]");

      private static byte[] GetHtmlContent(Request request)
      {
         const string title = "Sample WebListener";
         var builder =
            new StringBuilder("<h1>Hello from the server</h1>")
               .Append("Header Info")
               .Append(string.Join(" ", GetHeaderInfo(request.Headers)))
               .Append("<h2>Request Object Information</h2>")
               .Append(string.Join(" ", GetRequestInfo(request)));
         var html = string.Format(HtmlFormat, title, builder);

         return Encoding.UTF8.GetBytes(html);
      }

      private static IEnumerable<string> GetRequestInfo(Request request)
         =>
            request
               .GetType()
               .GetProperties()
               .Select(property => $"<div>{property.Name}: {property.GetValue(request)}</div>");

      private static IEnumerable<string> GetHeaderInfo(HeaderCollection headers)
         => headers.Keys.Select(key => $"<div>{key}: {string.Join(", ", headers.GetValues(key))}</div>");
   }
}