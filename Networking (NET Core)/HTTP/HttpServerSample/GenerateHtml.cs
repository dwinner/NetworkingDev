using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HttpServerSample
{
   public class GenerateHtml
   {
      private const string HtmlFormat =
         "<!DOCTYPE html>\r\n<html><head><title>{0}</title></head><body>{1}</body></html>";

      private readonly ILogger _logger;

      public GenerateHtml(ILogger<GenerateHtml> logger) => _logger = logger;

      public string GetHtmlContent(HttpRequest request)
      {
         const string title = "Sample Listener using Kestrel";

         string content =
            $"<h1>Hello from the server</h1><h2>Header Info</h2>{string.Join(' ', GetHeaderInfo(request.Headers))}<h2>Request Object Information</h2>{string.Join(' ', GetRequestInfo(request))}";

         return string.Format(HtmlFormat, title, content);
      }

      private IEnumerable<string> GetRequestInfo(HttpRequest request)
      {
         var properties = request.GetType().GetProperties();
         List<(string key, string value)> values = new();
         foreach (var property in properties)
         {
            try
            {
               var value = property.GetValue(request)?.ToString();
               if (value != null)
               {
                  values.Add((property.Name, value));
               }
            }
            catch (TargetInvocationException ex)
            {
               _logger.LogInformation("property name: {0}: message {1}", property.Name, ex.Message);
               if (ex.InnerException != null)
               {
                  _logger.LogInformation("\tinner exception: {0}", ex.InnerException.Message);
               }
            }
         }

         return values.Select(v => $"<div>{v.key}: {v.value}</div>");
      }

      private static IEnumerable<string> GetHeaderInfo(IHeaderDictionary headers)
      {
         List<(string key, string value)> values = new();
         var keys = headers.Keys;
         foreach (var key in keys)
         {
            if (headers.TryGetValue(key, out var value))
            {
               values.Add((key, value));
            }
         }

         return values.Select(v => $"<div>{v.key}: {v.value}</div>");
      }
   }
}