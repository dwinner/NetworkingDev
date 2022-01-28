/**
 * HTTP client sample
 */

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Console;

namespace HttpClientSample
{
   internal static class Program
   {
      private const string NorthwindUrl = "http://services.odata.org/Northwind/Northwind.svc/Regions";
      private const string IncorrectUrl = "http://services.odata.org/Northwind1/Northwind.svc/Regions";

      public static void Main(string[] args)
      {
         if (args.Length != 1)
         {
            ShowUsage();
            return;
         }

         switch (args[0].ToLower())
         {
            case "-s":
               GetDataSimpleAsync().Wait();
               break;
            case "-a":
               GetDataAdvancedAsync().Wait();
               break;
            case "-e":
               GetDataWithExceptionsAsync().Wait();
               break;
            case "-h":
               GetDataWithHeadersAsync().Wait();
               break;
            case "-mh":
               GetDataWithMessageHandlerAsync().Wait();
               break;
            default:
               ShowUsage();
               break;
         }

         ReadLine();
      }

      private static async Task GetDataSimpleAsync()
      {
         using (var client = new HttpClient())
         {
            var response = await client.GetAsync(NorthwindUrl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
               WriteLine($"Response Status Code: {(int) response.StatusCode} {response.ReasonPhrase}");
               var responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
               WriteLine($"Received payload of {responseBodyAsText.Length} characters");
               WriteLine();
               WriteLine(responseBodyAsText);
            }
         }
      }

      private static async Task GetDataAdvancedAsync()
      {
         using (var client = new HttpClient())
         {
            var request = new HttpRequestMessage(HttpMethod.Get, NorthwindUrl);
            var response = await client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
               WriteLine($"Response Status Code: {(int) response.StatusCode} {response.ReasonPhrase}");
               var responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
               WriteLine($"Received payload of {responseBodyAsText.Length} characters");
               WriteLine();
               WriteLine(responseBodyAsText);
            }
         }
      }

      private static async Task GetDataWithExceptionsAsync()
      {
         try
         {
            using (var client = new HttpClient())
            {
               client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
               ShowHeaders("Request Headers:", client.DefaultRequestHeaders);
               var response = await client.GetAsync(IncorrectUrl).ConfigureAwait(false);
               response.EnsureSuccessStatusCode();

               ShowHeaders("Response Headers:", response.Headers);

               WriteLine($"Response Status Code: {response.StatusCode} {response.ReasonPhrase}");
               var responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
               WriteLine($"Received payload of {responseBodyAsText.Length} characters");
               WriteLine();
               WriteLine(responseBodyAsText);
            }
         }
         catch (Exception ex)
         {
            WriteLine($"{ex.Message}");
         }
      }

      private static async Task GetDataWithMessageHandlerAsync()
      {
         try
         {
            using (var client = new HttpClient(new SampleMessageHandler("error")))
            {
               client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
               ShowHeaders("Request Headers:", client.DefaultRequestHeaders);

               var response = await client.GetAsync(NorthwindUrl).ConfigureAwait(false);
               response.EnsureSuccessStatusCode();

               ShowHeaders("Response Headers:", response.Headers);

               WriteLine($"Response Status Code: {response.StatusCode} {response.ReasonPhrase}");
               var responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
               WriteLine($"Received payload of {responseBodyAsText.Length} characters");
               WriteLine();
               WriteLine(responseBodyAsText);
            }
         }
         catch (Exception ex)
         {
            WriteLine($"{ex.Message}");
         }
      }

      private static async Task GetDataWithHeadersAsync()
      {
         try
         {
            using (var client = new HttpClient())
            {
               client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
               ShowHeaders("Request Headers:", client.DefaultRequestHeaders);

               var response = await client.GetAsync(NorthwindUrl).ConfigureAwait(false);
               response.EnsureSuccessStatusCode();

               ShowHeaders("Response Headers:", response.Headers);

               WriteLine($"Response Status Code: {response.StatusCode} {response.ReasonPhrase}");
               var responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
               WriteLine($"Received payload of {responseBodyAsText.Length} characters");
               WriteLine();
               WriteLine(responseBodyAsText);
            }
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }
      }

      private static void ShowHeaders(string title, HttpHeaders headers)
      {
         WriteLine(title);
         foreach (var header in headers)
         {
            string.Join(" ", header.Value);
            WriteLine($"Header: {header.Key} Value: {header.Value}");
         }

         WriteLine();
      }

      private static void ShowUsage()
      {
         WriteLine("Usage: HttpClientSample command");
         WriteLine("commands:");
         WriteLine("\t-s\tSimple");
         WriteLine("\t-a\tAdvanced");
         WriteLine("\t-e\tUsing Exceptions");
         WriteLine("\t-h\tWith Headers");
         WriteLine("\t-mh\tWith message handler");
      }
   }
}