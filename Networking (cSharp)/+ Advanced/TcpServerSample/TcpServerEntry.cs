using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static TcpServerSample.CustomProtocol;

namespace TcpServerSample
{
   public sealed class TcpServerEntry
   {
      private const int PortNumber = 8800;
      private readonly CommandActions _commandActions = new CommandActions();
      private readonly SessionManager _sessionManager = new SessionManager();

      public static void Main()
      {
         var tcpServer = new TcpServerEntry();
         tcpServer.Run();
      }

      private void Run()
      {
         using ( /*var timer = */
            new Timer(SessionCleanupCallback, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1)))
         {
            RunServerAsync().Wait();
         }
      }

      private void SessionCleanupCallback(object state) => _sessionManager.CleanupAll();

      private async Task RunServerAsync()
      {
         try
         {
            var listener = new TcpListener(IPAddress.Any, PortNumber);
            WriteLine($"Listener started at port {PortNumber}");
            listener.Start();

            while (true)
            {
               WriteLine("Waiting for client...");
               var client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
               await RunClientRequestAsync(client).ConfigureAwait(false);
            }
         }
         catch (Exception ex)
         {
            WriteLine($"Exception of type {ex.GetType().Name}, Message: {ex.Message}");
         }
      }

      private Task RunClientRequestAsync(TcpClient client)
         => Task.Run(async () =>
         {
            try
            {
               using (client)
               {
                  WriteLine("Client connected");

                  using (var stream = client.GetStream())
                  {
                     var completed = false;

                     do
                     {
                        const int bufferCount = 0x400;
                        var readBuffer = new byte[bufferCount];
                        var read = await stream.ReadAsync(readBuffer, 0, readBuffer.Length)
                           .ConfigureAwait(false);
                        var request = Encoding.ASCII.GetString(readBuffer, 0, read);
                        WriteLine($"Received {request}");

                        string sessionId, result, response = string.Empty;
                        byte[] writeBuffer = null;

                        var responseStatus = ParseRequest(request, out sessionId, out result);
                        switch (responseStatus)
                        {
                           case ParseResponse.Ok:
                              var content = $"{StatusOk}{Separator}{SessionId}{Separator}{sessionId}";
                              if (!string.IsNullOrEmpty(result))
                              {
                                 content += $"{Separator}{result}";
                                 response =
                                    $"{StatusOk}{Separator}{SessionId}{Separator}{sessionId}{Separator}{content}";
                              }

                              break;

                           case ParseResponse.Close:
                              response = $"{StatusClosed}";
                              completed = true;
                              break;

                           case ParseResponse.Error:
                              response = $"{StatusInvalid}";
                              break;

                           case ParseResponse.Timeout:
                              response = $"{StatusTimeout}";
                              break;

                           default:
                              throw new ArgumentOutOfRangeException(responseStatus.ToString());
                        }

                        writeBuffer = Encoding.ASCII.GetBytes(response);
                        await stream.WriteAsync(writeBuffer, 0, writeBuffer.Length).ConfigureAwait(false);
                        await stream.FlushAsync().ConfigureAwait(false);
                        WriteLine($"Returned {Encoding.ASCII.GetString(writeBuffer, 0, writeBuffer.Length)}");
                     }
                     while (!completed);
                  }
               }
            }
            catch (Exception ex)
            {
               WriteLine($"Exception {ex.GetType().Name}, Message: {ex.Message}");
            }

            WriteLine("Client disconnected");
         });

      private ParseResponse ParseRequest(string request, out string sessionId, out string response)
      {
         sessionId = string.Empty;
         response = string.Empty;
         var requestColl = request.Split(new[] {Separator}, StringSplitOptions.RemoveEmptyEntries);
         switch (requestColl[0])
         {
            case CommandHelo:
               sessionId = _sessionManager.Create();
               break;

            case SessionId:
               sessionId = requestColl[1];

               if (!_sessionManager.Touch(sessionId))
               {
                  return ParseResponse.Timeout;
               }

               if (requestColl[2] == CommandBye)
               {
                  return ParseResponse.Close;
               }

               if (requestColl.Length >= 4)
               {
                  response = ProcessRequest(requestColl);
               }

               break;

            default:
               return ParseResponse.Error;
         }

         return ParseResponse.Ok;
      }

      private string ProcessRequest(IReadOnlyList<string> requestColl)
      {
         if (requestColl.Count < 4)
         {
            throw new ArgumentException("Invalid length requestColl");
         }

         var sessionId = requestColl[1];
         string response;
         var requestCommand = requestColl[2];
         var requestAction = requestColl[3];

         switch (requestCommand)
         {
            case CommandEcho:
               response = _commandActions.Echo(requestAction);
               break;

            case CommandRev:
               response = _commandActions.Reverse(requestAction);
               break;

            case CommandSet:
               response = _sessionManager.ParseData(sessionId, requestAction);
               break;

            case CommandGet:
               response = $"{_sessionManager.GetData(sessionId, requestAction)}";
               break;

            default:
               response = StatusUnknown;
               break;
         }

         return response;
      }
   }
}