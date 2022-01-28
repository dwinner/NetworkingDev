using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading;
using HttpClientSample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

await BuildCommandLine()
   .UseHost(_ => GetHostBuilder())
   .UseDefaults()
   .Build()
   .InvokeAsync(args);

IHostBuilder GetHostBuilder() =>
   Host.CreateDefaultBuilder()
      .ConfigureServices((context, services) =>
      {
         var httpClientSettings = context.Configuration.GetSection("HttpClient");
         services.Configure<HttpClientSampleOptions>(httpClientSettings);
         services.AddHttpClient<HttpClientSamples>(httpClient =>
         {
            httpClient.BaseAddress = new Uri(httpClientSettings["Url"]);
         });

         services.Configure<LimitCallsHandlerOptions>(context.Configuration.GetSection("RateLimit"));
         services.AddTransient<LimitCallsHandler>();
         services.AddHttpClient<HttpClientSampleWithMessageHandler>(httpClient =>
         {
            httpClient.BaseAddress = new Uri(httpClientSettings["Url"]);
         }).AddHttpMessageHandler<LimitCallsHandler>().SetHandlerLifetime(Timeout.InfiniteTimeSpan);

         services.AddHttpClient("racersClient")
            .ConfigureHttpClient(httpClient => { httpClient.BaseAddress = new Uri(httpClientSettings["Url"]); });
         services.AddTransient<NamedClientSample>();

         services.AddHttpClient<FaultHandlingSample>(httpClient =>
            {
               httpClient.BaseAddress = new Uri(httpClientSettings["InvalidUrl"]);
            })
            //.AddPolicyHandler(GetRetryPolicy())
            .AddTransientHttpErrorPolicy(
               policy => policy.WaitAndRetryAsync(new[]
                  { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(5) }));
      });

/*
IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
   => HttpPolicyExtensions
      .HandleTransientHttpError()
      .OrResult(message => message.StatusCode == HttpStatusCode.TooManyRequests)
      .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(4, retryAttempt)));
*/

CommandLineBuilder BuildCommandLine()
{
   RootCommand rootCommand = new("HttpClientSample");
   Command simpleCommand = new("simple")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<HttpClientSamples>();
         return service.SimpleGetRequestAsync();
      })
   };
   rootCommand.AddCommand(simpleCommand);

   Command httpRequestMessageCommand = new("httprequest")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<HttpClientSamples>();
         return service.UseHttpRequestMessageAsync();
      })
   };
   rootCommand.AddCommand(httpRequestMessageCommand);

   Command exceptionCommand = new("exception")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<HttpClientSamples>();
         return service.ThrowExceptionAsync();
      })
   };
   rootCommand.AddCommand(exceptionCommand);

   Command headerCommand = new("headers")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<HttpClientSamples>();
         return service.AddHttpHeadersAsync();
      })
   };
   rootCommand.AddCommand(headerCommand);

   Command http2Command = new("http2")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<HttpClientSamples>();
         return service.UseHttp2();
      })
   };
   rootCommand.AddCommand(http2Command);

   Command messageHandlerCommand = new("messagehandler")
   {
      Handler = CommandHandler.Create<IHost>(async host =>
      {
         var service = host.Services.GetRequiredService<HttpClientSampleWithMessageHandler>();
         for (var i = 0; i < 10; i++)
         {
            await service.UseMessageHandlerAsync();
         }
      })
   };
   rootCommand.AddCommand(messageHandlerCommand);

   Command namedClientCommand = new("named")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<NamedClientSample>();
         return service.RunAsync();
      })
   };
   rootCommand.AddCommand(namedClientCommand);

   Command pollyCommand = new("retry")
   {
      Handler = CommandHandler.Create<IHost>(host =>
      {
         var service = host.Services.GetRequiredService<FaultHandlingSample>();
         return service.RunAsync();
      })
   };
   rootCommand.AddCommand(pollyCommand);

   return new CommandLineBuilder(rootCommand);
}