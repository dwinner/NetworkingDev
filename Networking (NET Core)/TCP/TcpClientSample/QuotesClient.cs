using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

internal class QuotesClient
{
   private readonly string _hostname;
   private readonly ILogger _logger;
   private readonly int _serverPort;

   public QuotesClient(IOptions<QuotesClientOptions> options, ILogger<QuotesClient> logger)
   {
      var clientOptions = options.Value;
      _hostname = clientOptions.Hostname ?? "localhost";
      _serverPort = clientOptions.ServerPort;
      _logger = logger;
   }

   public async Task SendAndReceiveAsync(CancellationToken cancellationToken = default)
   {
      try
      {
         var buffer = new byte[4096].AsMemory();
         var repeat = true;
         while (repeat)
         {
            Console.WriteLine(@"Press enter to read a quote, ""bye"" to exit");
            var line = Console.ReadLine();
            if (line?.Equals("bye", StringComparison.CurrentCultureIgnoreCase) == true)
            {
               repeat = false;
            }
            else
            {
               TcpClient client = new();
               await client.ConnectAsync(_hostname, _serverPort, cancellationToken).ConfigureAwait(false);
               await using var stream = client.GetStream();
               var bytesRead = await stream.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
               string quote = Encoding.UTF8.GetString(buffer.Span[..bytesRead]);
               buffer.Span[..bytesRead].Clear();
               Console.WriteLine(quote);
               Console.WriteLine();
            }
         }
      }
      catch (SocketException ex)
      {
         _logger.LogError(ex, ex.Message);
      }

      Console.WriteLine("so long, and thanks for all the fish");
   }
}