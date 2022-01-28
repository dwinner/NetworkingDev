using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TcpConsoleClientSample
{
   public class Program
   {
      private const string Host = "localhost";
      private const int Port = 8800;

      public static void Main()
      {
         SendAndReceiveAsync().Wait();
         ReadLine();
      }

      private static async Task SendAndReceiveAsync()
      {
         var defaultEncoding = Encoding.ASCII;
         const int bufferSize = 1024;

         using (var client = new TcpClient())
         {
            await client.ConnectAsync(Host, Port).ConfigureAwait(false);
            using (var stream = client.GetStream())
            using (var writer = new StreamWriter(stream, defaultEncoding, bufferSize, true) {AutoFlush = true})
            using (var reader = new StreamReader(stream, defaultEncoding, true, bufferSize, true))
            {
               string line;
               do
               {
                  WriteLine("Enter a string, bye to exit");
                  line = ReadLine();
                  await writer.WriteLineAsync(line).ConfigureAwait(false);
                  var result = await reader.ReadLineAsync().ConfigureAwait(false);
                  WriteLine($"Received {result} from server");
               }
               while (line != "bye");

               WriteLine("So long, and thanks for all the fish");
            }
         }
      }
   }
}