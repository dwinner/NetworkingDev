using Books.Data.Models;
using Books.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = new HostBuilder()
   .ConfigureFunctionsWorkerDefaults()
   .ConfigureServices(services =>
   {
      var connectionString = Environment.GetEnvironmentVariable("BooksConnection");
      if (connectionString is null)
      {
         throw new InvalidOperationException("Configure the BooksConnection");
      }

      services.AddDbContext<IBookChapterService, BooksContext>(options => { options.UseSqlServer(connectionString); });
   })
   .Build();

await host.RunAsync().ConfigureAwait(false);