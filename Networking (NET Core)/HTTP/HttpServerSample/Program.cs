using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HttpServerSample
{
   public static class Program
   {
      public static void Main(string[] args)
      {
         CreateHostBuilder(args).Build().Run();
      }

      private static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder
               .UseStartup<Startup>()
               .ConfigureKestrel(options =>
               {
                  options.AddServerHeader = true;
                  options.AllowResponseHeaderCompression = true;
                  options.Limits.Http2.MaxStreamsPerConnection = 10;
                  options.Limits.MaxConcurrentConnections = 20;
                  options.ConfigureHttpsDefaults(_ => { });
               })
               .UseUrls("http://localhost:5020", "https://localhost:5021"));
   }
}