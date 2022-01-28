/**
 * Разбор и построение Uri из компонентов
 */

using System;

namespace UriComponentsSample
{
   class Program
   {
      private const string RuTrackerUrl = "http://rutracker.org/forum/viewtopic.php?t=4726276";

      static void Main()
      {
         // Разбор Uri на компоненты
         var pageUri = new Uri(RuTrackerUrl);
         string query = pageUri.Query;
         string absPath = pageUri.AbsolutePath;
         string scheme = pageUri.Scheme;
         int port = pageUri.Port;
         string host = pageUri.Host;
         bool isDefaultPort = pageUri.IsDefaultPort;
         string[] pathSegments = pageUri.Segments;
         Console.WriteLine("Query: {0}", query);
         Console.WriteLine("Absolute Path: {0}", absPath);
         Console.WriteLine("Scheme: {0}", scheme);
         Console.WriteLine("Port: {0}", port);
         Console.WriteLine("Host: {0}", host);
         Console.WriteLine("Is Default Port: {0}", isDefaultPort);
         Console.WriteLine("Path segments:");
         foreach (var pathSegment in pathSegments)
         {
            Console.WriteLine(pathSegment);
         }

         // Построение Uri из компонентов
         var uriBuilder = new UriBuilder()
         {
            Scheme = scheme,
            Host = host,
            Port = port,
            Path = absPath
         };
         Uri completedUri = uriBuilder.Uri;
         string absoluteUri = completedUri.AbsoluteUri;
         Console.WriteLine(absoluteUri);
      }
   }
}
