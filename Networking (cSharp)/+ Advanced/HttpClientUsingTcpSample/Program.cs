/**
 * Low level HTTP client via TCP protocol
 */

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HttpClientUsingTcpSample
{
   internal static class Program
   {
      private const int ReadBufferSize = 0x400;
      private const int DefaultHttpPort = 80;

      private static void Main(string[] args)
      {
         var hostPort = args.Length != 2
            ? Tuple.Create("yandex.ru", DefaultHttpPort)
            : Tuple.Create(args[0], int.Parse(args[1]));
         var htmlTask = RequestHtmlAsync(hostPort.Item1, hostPort.Item2);
         WriteLine(htmlTask.Result);
         ReadLine();
      }

      private static async Task<string> RequestHtmlAsync(string aHostName, int aPort = DefaultHttpPort)
      {
         try
         {
            using (var client = new TcpClient())
            {
               await client.ConnectAsync(aHostName, aPort).ConfigureAwait(false);
               using (var stream = client.GetStream())
               {
                  var requestHeader = "GET / HTTP/1.1\r\n" +
                                      $"Host: {aHostName}:{aPort}\r\n" +
                                      "Connection: close\r\n" +
                                      "\r\n";
                  var buffer = Encoding.UTF8.GetBytes(requestHeader);
                  await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                  await stream.FlushAsync().ConfigureAwait(false);

                  using (var responseStream = new MemoryStream())
                  {
                     buffer = new byte[ReadBufferSize];
                     int read;
                     do
                     {
                        read = await stream.ReadAsync(buffer, 0, ReadBufferSize).ConfigureAwait(false);
                        await responseStream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                        Array.Clear(buffer, 0, buffer.Length);
                     }
                     while (read > 0);

                     responseStream.Seek(0, SeekOrigin.Begin);
                     using (var reader = new StreamReader(responseStream))
                     {
                        return await reader.ReadToEndAsync().ConfigureAwait(false);
                     }
                  }
               }
            }
         }
         catch (SocketException socketEx)
         {
            WriteLine(socketEx.Message);
            return string.Empty;
         }
      }
   }
}