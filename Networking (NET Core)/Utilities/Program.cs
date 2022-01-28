using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Net;

await BuildCommandLine()
   .UseDefaults()
   .Build()
   .InvokeAsync(args).ConfigureAwait(false);

CommandLineBuilder BuildCommandLine()
{
   RootCommand rootCommand = new("Utilities");

   Command uriCommand = new("uri", "Show the parts of the URI, e.g. www.wrox.com")
   {
      new Option<string>("--uri")
      {
         IsRequired = false
      }
   };
   uriCommand.Handler = CommandHandler.Create<string>(UriSample);

   Command ipCommand = new("ip", "Show the part of the IP address, e.g. ipaddress 234.56.78.9")
   {
      new Option<string>("--ip")
      {
         IsRequired = false
      }
   };
   ipCommand.Handler = CommandHandler.Create<string>(IpAddressSample);

   Command buildUriCommand = new("builduri", "Buils an URI using the UriBuilder")
   {
      Handler = CommandHandler.Create(BuildUri)
   };

   rootCommand.AddCommand(uriCommand);
   rootCommand.AddCommand(ipCommand);
   rootCommand.AddCommand(buildUriCommand);

   return new CommandLineBuilder(rootCommand);
}

static void IpAddressSample(string ipAddressString)
{
   if (!IPAddress.TryParse(ipAddressString, out var address))
   {
      Console.WriteLine($"cannot parse {ipAddressString}");
      return;
   }

   byte[] bytes = address.GetAddressBytes();
   for (var i = 0; i < bytes.Length; i++)
   {
      Console.WriteLine($"byte {i}: {bytes[i]:X}");
   }

   Console.WriteLine(
      $"family: {address.AddressFamily}, map to ipv6: {address.MapToIPv6()}, map to ipv4: {address.MapToIPv4()}");
   Console.WriteLine($"IPv4 loopback address: {IPAddress.Loopback}");
   Console.WriteLine($"IPv6 loopback address: {IPAddress.IPv6Loopback}");
   Console.WriteLine($"IPv4 broadcast address: {IPAddress.Broadcast}");
   Console.WriteLine($"IPv4 any address: {IPAddress.Any}");
   Console.WriteLine($"IPv6 any address: {IPAddress.IPv6Any}");
}

static void UriSample(string uri)
{
   Uri page = new(uri);
   Console.WriteLine($"scheme: {page.Scheme}");
   Console.WriteLine($"host: {page.Host}, type:  {page.HostNameType}, idn host: {page.IdnHost}");
   Console.WriteLine($"port: {page.Port}");
   Console.WriteLine($"path: {page.AbsolutePath}");
   Console.WriteLine($"query: {page.Query}");
   foreach (var segment in page.Segments)
   {
      Console.WriteLine($"segment: {segment}");
   }
}

static void BuildUri()
{
   UriBuilder builder = new()
   {
      Scheme = "https",
      Host = "www.cninnovation.com",
      Port = 443,
      Path = "training/MVC"
   };
   Uri uri = builder.Uri;
   Console.WriteLine(uri);
}