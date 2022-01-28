using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace SocketClient
{
   internal static class SocketClientEntry
   {
      private const int ReadBufferSize = 1024;

      private static void Main(string[] args)
      {
         if (args.Length != 2)
         {
            ShowUsage();
            return;
         }

         var hostName = args[0];
         int port;
         if (!int.TryParse(args[1], out port))
         {
            ShowUsage();
            return;
         }

         WriteLine("press return when the server is started");
         ReadLine();

         SendAndReceiveAsync(hostName, port).Wait();
         ReadLine();
      }

      private static void ShowUsage() => WriteLine("Usage: SocketClient server port");

      private static async Task SendAndReceiveAsync(string hostName, int port)
      {
         try
         {
            var ipHost = await Dns.GetHostEntryAsync(hostName).ConfigureAwait(false);
            var ipAddress =
               ipHost.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork);
            if (ipAddress == null)
            {
               WriteLine("no IPv4 address");
               return;
            }

            using (var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
               client.Connect(ipAddress, port);
               WriteLine("client successfully connected");
               using (var stream = new NetworkStream(client))
               {
                  var tokenSource = new CancellationTokenSource();
                  var tSender = SendAsync(stream, tokenSource);
                  var tReceiver = ReceiveAsync(stream, tokenSource.Token);
                  await Task.WhenAll(tSender, tReceiver).ConfigureAwait(false);
               }
            }
         }
         catch (SocketException ex)
         {
            WriteLine(ex.Message);
         }
      }

      private static async Task SendAsync(Stream stream, CancellationTokenSource tokenSource)
      {
         WriteLine("Sender task");
         while (true)
         {
            WriteLine("enter a string to send, shutdown to exit");
            var line = ReadLine();
            var buffer = Encoding.UTF8.GetBytes($"{line}\r\n");
            await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            await stream.FlushAsync().ConfigureAwait(false);
            if (string.Compare(line, "shutdown", StringComparison.OrdinalIgnoreCase) == 0)
            {
               tokenSource.Cancel();
               WriteLine("sender task closes");
               break;
            }
         }
      }

      private static async Task ReceiveAsync(Stream stream, CancellationToken token)
      {
         try
         {
            stream.ReadTimeout = 5000;
            WriteLine("Receiver task");
            var readBuffer = new byte[ReadBufferSize];
            while (true)
            {
               Array.Clear(readBuffer, 0, ReadBufferSize);
               var read = await stream.ReadAsync(readBuffer, 0, ReadBufferSize, token).ConfigureAwait(false);
               var receivedLine = Encoding.UTF8.GetString(readBuffer, 0, read);
               WriteLine($"received {receivedLine}");
            }
         }
         catch (OperationCanceledException ex)
         {
            WriteLine(ex.Message);
         }
      }
   }
}