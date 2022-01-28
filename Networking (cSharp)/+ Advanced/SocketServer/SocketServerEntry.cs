using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace SocketServer
{
   internal static class SocketServerEntry
   {
      private static void Main(string[] args)
      {
         if (args.Length != 1)
         {
            ShowUsage();
            return;
         }

         int port;
         if (!int.TryParse(args[0], out port))
         {
            ShowUsage();
            return;
         }

         Listener(port);
         ReadLine();
      }

      private static void ShowUsage() => WriteLine("SocketServer port");

      private static void Listener(int port)
      {
         var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
         {
            ReceiveTimeout = 5000, // receive timout 5 seconds
            SendTimeout = 5000 // send timeout 5 seconds 
         };

         listener.Bind(new IPEndPoint(IPAddress.Any, port));
         listener.Listen(15);

         WriteLine($"listener started on port {port}");

         var tokenSource = new CancellationTokenSource();
         var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
         taskFactory.StartNew(() => // listener task
         {
            WriteLine("listener task started");
            while (true)
            {
               if (tokenSource.Token.IsCancellationRequested)
               {
                  tokenSource.Token.ThrowIfCancellationRequested();
                  break;
               }

               WriteLine("waiting for accept");
               var client = listener.Accept();
               if (!client.Connected)
               {
                  WriteLine("not connected");
                  continue;
               }

               WriteLine(
                  $"client connected local address {((IPEndPoint) client.LocalEndPoint).Address} and port {((IPEndPoint) client.LocalEndPoint).Port}, remote address {((IPEndPoint) client.RemoteEndPoint).Address} and port {((IPEndPoint) client.RemoteEndPoint).Port}");

               /*var t = */
               CommunicateWithClientUsingSocketAsync(client);
            }

            listener.Dispose();
            WriteLine("Listener task closing");
         }, tokenSource.Token);

         WriteLine("Press return to exit");
         ReadLine();
         tokenSource.Cancel();
      }

      private static Task CommunicateWithClientUsingSocketAsync(Socket socket)
         => Task.Run(() =>
         {
            try
            {
               using (socket)
               {
                  var completed = false;
                  do
                  {
                     const int readBufferSize = 1024;
                     var readBuffer = new byte[readBufferSize];
                     var read = socket.Receive(readBuffer, 0, readBufferSize, SocketFlags.None);
                     var fromClient = Encoding.UTF8.GetString(readBuffer, 0, read);
                     WriteLine($"read {read} bytes: {fromClient}");
                     if (string.Compare(fromClient, "shutdown", StringComparison.OrdinalIgnoreCase) == 0)
                     {
                        completed = true;
                     }

                     var writeBuffer = Encoding.UTF8.GetBytes($"echo {fromClient}");
                     var send = socket.Send(writeBuffer);
                     WriteLine($"sent {send} bytes");
                  }
                  while (!completed);
               }

               WriteLine("closed stream and client socket");
            }
            catch (SocketException ex)
            {
               WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
               WriteLine(ex.Message);
            }
         });

      private static async Task CommunicateWithClientUsingNetworkStreamAsync(Socket socket)
      {
         try
         {
            using (var stream = new NetworkStream(socket, true))
            {
               var completed = false;
               do
               {
                  const int readBuffersize = 1024;
                  var readBuffer = new byte[readBuffersize];
                  var read = await stream.ReadAsync(readBuffer, 0, readBuffersize).ConfigureAwait(false);
                  var fromClient = Encoding.UTF8.GetString(readBuffer, 0, read);
                  WriteLine($"read {read} bytes: {fromClient}");
                  if (string.Compare(fromClient, "shutdown", StringComparison.OrdinalIgnoreCase) == 0)
                  {
                     completed = true;
                  }

                  var writeBuffer = Encoding.UTF8.GetBytes($"echo {fromClient}");
                  await stream.WriteAsync(writeBuffer, 0, writeBuffer.Length).ConfigureAwait(false);
               }
               while (!completed);
            }

            WriteLine("closed stream and client socket");
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }
      }

      private static async Task CommunicateWithClientUsingReadersAndWritersAsync(Socket socket)
      {
         try
         {
            using (var networkStream = new NetworkStream(socket, true))
            using (var reader = new StreamReader(networkStream, Encoding.UTF8, false, 8192, true))
            using (var writer = new StreamWriter(networkStream, Encoding.UTF8, 8192, true) {AutoFlush = true})
            {
               var completed = false;
               do
               {
                  var fromClient = await reader.ReadLineAsync().ConfigureAwait(false);
                  WriteLine($"read {fromClient}");
                  if (string.Compare(fromClient, "shutdown", StringComparison.OrdinalIgnoreCase) == 0)
                  {
                     completed = true;
                  }

                  await writer.WriteLineAsync($"echo {fromClient}").ConfigureAwait(false);
               }
               while (!completed);
            }

            WriteLine("closed stream and client socket");
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }
      }
   }
}