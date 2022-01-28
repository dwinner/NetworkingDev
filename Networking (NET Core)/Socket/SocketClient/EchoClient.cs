using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

internal class EchoClient
{
   private readonly string _hostname;
   private readonly ILogger _logger;
   private readonly int _serverPort;

   public EchoClient(IOptions<EchoClientOptions> options, ILogger<EchoClient> logger)
   {
      var clientOptions = options.Value;
      _hostname = clientOptions.Hostname ?? "localhost";
      _serverPort = clientOptions.ServerPort;
      _logger = logger;
   }

   public async Task SendAndReceiveAsync(CancellationToken cancellationToken)
   {
      try
      {
         var addresses = await Dns.GetHostAddressesAsync(_hostname).ConfigureAwait(false);
         IPAddress ipAddress = addresses.First(address => address.AddressFamily == AddressFamily.InterNetwork);
         Socket clientSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         await clientSocket.ConnectAsync(ipAddress, _serverPort, cancellationToken).ConfigureAwait(false);

         _logger.LogInformation("client connected to echo service");
         await using NetworkStream stream = new(clientSocket, true);

         Console.WriteLine("enter text that is streamed to the server and returned");

         // send the input to the network stream
         Stream consoleInput = Console.OpenStandardInput();
         Task sender = consoleInput.CopyToAsync(stream, cancellationToken);

         // receive the output from the network stream
         Stream consoleOutput = Console.OpenStandardOutput();
         Task receiver = stream.CopyToAsync(consoleOutput, cancellationToken);

         await Task.WhenAll(sender, receiver).ConfigureAwait(false);
         _logger.LogInformation("sender and receiver completed");
      }
      catch (SocketException ex) when (ex.ErrorCode == 10061)
      {
         _logger.LogError("Is the server running?");
      }
      catch (SocketException ex)
      {
         _logger.LogError(ex, ex.Message);
      }
      catch (OperationCanceledException ex)
      {
         _logger.LogInformation(ex.Message);
      }
   }
}