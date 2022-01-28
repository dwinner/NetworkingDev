using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
   .ConfigureServices((context, services) =>
   {
      var settings = context.Configuration;
      services.Configure<QuotesServerOptions>(settings.GetSection("QuotesServer"));
      services.AddTransient<QuotesServer>();
   })
   .Build();

var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger("QuotesServer");
CancellationTokenSource cancellationTokenSource = new();
Console.CancelKeyPress += (_, _) =>
{
   logger.LogInformation("cancellation initiated by the user");
   cancellationTokenSource.Cancel();
};

try
{
   var service = host.Services.GetRequiredService<QuotesServer>();
   await service.InitializeAsync().ConfigureAwait(true);
   await service.RunServerAsync(cancellationTokenSource.Token).ConfigureAwait(false);
}
catch (Exception ex)
{
   logger.LogError(ex, ex.Message);
   Environment.Exit(-1);
}

Console.ReadLine();