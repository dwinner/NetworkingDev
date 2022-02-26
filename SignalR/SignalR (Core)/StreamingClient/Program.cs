using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Wait for service - press return to start");
Console.ReadLine();

var connection = new HubConnectionBuilder()
   .WithUrl("https://localhost:5001/stream")
   .Build();

await connection.StartAsync().ConfigureAwait(false);

CancellationTokenSource cts = new(10000);

try
{
   await foreach (var data in connection.StreamAsync<SensorData>("GetSensorData").WithCancellation(cts.Token))
   {
      Console.WriteLine(data);
   }
}
catch (OperationCanceledException)
{
   Console.WriteLine("Cancelled!");
}

await connection.StopAsync().ConfigureAwait(false);

Console.WriteLine("Completed");


public record SensorData(int Val1, int Val2, DateTime TimeStamp);