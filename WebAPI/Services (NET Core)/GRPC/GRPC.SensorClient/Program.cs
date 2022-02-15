using System;
using GRPC.SensorClient;
using GRPCService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
   .ConfigureServices((context, services) =>
   {
      services.AddGrpcClient<Sensor.SensorClient>(options =>
      {
         var grpcServiceUri = context.Configuration["GrpcServiceUri"] ?? "https://localhost:5001";
         options.Address = new Uri(grpcServiceUri);
         options.ChannelOptionsActions.Add(opt => { opt.ThrowOperationCanceledOnCancellation = true; });
      });

      services.AddSingleton<Runner>();
   })
   .Build();

Console.WriteLine("press return to start");
Console.ReadLine();

var runner = host.Services.GetRequiredService<Runner>();
await runner.RunAsync().ConfigureAwait(false);

Console.ReadLine();