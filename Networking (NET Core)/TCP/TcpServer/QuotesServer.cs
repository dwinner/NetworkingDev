using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
// ReSharper disable FunctionNeverReturns

internal class QuotesServer
{
   private readonly ILogger _logger;
   private readonly int _port;
   private readonly string _quotesPath;
   private readonly Random _random = new();
   private string[]? _quotes;

   public QuotesServer(IOptions<QuotesServerOptions> options, ILogger<QuotesServer> logger)
   {
      var serverOptions = options.Value;
      _port = serverOptions.Port;
      _quotesPath = serverOptions.QuotesFile ?? "quotes.txt";
      _logger = logger;
   }

   public async Task InitializeAsync(CancellationToken cancellationToken = default)
      => _quotes = await File.ReadAllLinesAsync(_quotesPath, cancellationToken).ConfigureAwait(false);

   public async Task RunServerAsync(CancellationToken cancellationToken = default)
   {
      TcpListener listener = new(IPAddress.Any, _port);
      _logger.LogInformation("Quotes listener started on port {0}", _port);
      listener.Start();

      while (true)
      {
         cancellationToken.ThrowIfCancellationRequested();
         using TcpClient tcpClient = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
         _logger.LogInformation("Client connected with address and port: {0}", tcpClient.Client.RemoteEndPoint);
         var _ = SendQuoteAsync(tcpClient, cancellationToken);
      }
   }

   private async Task SendQuoteAsync(TcpClient client, CancellationToken cancellationToken = default)
   {
      try
      {
         client.LingerState = new LingerOption(true, 10);
         client.NoDelay = true;

         await using var stream = client.GetStream(); // returns a stream that owns the socket
         var quote = GetRandomQuote();
         var buffer = Encoding.UTF8.GetBytes(quote).AsMemory();
         await stream.WriteAsync(buffer, cancellationToken).ConfigureAwait(false);
      }
      catch (IOException ex)
      {
         _logger.LogError(ex, ex.Message);
      }
      catch (SocketException ex)
      {
         _logger.LogError(ex, ex.Message);
      }
   }

   private string GetRandomQuote()
   {
      if (_quotes is null)
      {
         throw new InvalidOperationException($"Invoke InitializeAsync before calling {nameof(GetRandomQuote)}");
      }

      return _quotes[_random.Next(_quotes.Length)];
   }
}