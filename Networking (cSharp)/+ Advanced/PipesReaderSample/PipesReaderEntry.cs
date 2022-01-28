/**
 * Pipe server impl
 */

using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PipesReaderSample
{
   public class PipesReaderEntry
   {
      public static void Main(string[] args)
      {
         var pipeName = args.Length == 1 ? args[0] : "MyPipe";
         if (pipeName == "anon")
         {
            AnonymousReaderAsync().Wait();
         }
         else
         {
            PipesReaderAsync(pipeName).Wait();
         }
      }

      private static async Task AnonymousReaderAsync()
      {
         using (var reader = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable))
         {
            WriteLine("Using anonymous pipe");
            var pipeHandle = reader.GetClientHandleAsString();
            WriteLine($"Pipe handle: {pipeHandle}");

            const int bufferSize = 0x100;
            var buffer = new byte[bufferSize];
            /*var nRead = */
            await reader.ReadAsync(buffer, 0, bufferSize).ConfigureAwait(false);
            var line = Encoding.UTF8.GetString(buffer, 0, bufferSize);
            WriteLine(line);
         }
      }

      private static async Task PipesReaderAsync(string pipeName)
      {
         try
         {
            using (var pipeReader = new NamedPipeServerStream(pipeName, PipeDirection.In))
            using (var reader = new StreamReader(pipeReader))
            {
               await pipeReader.WaitForConnectionAsync().ConfigureAwait(false);
               WriteLine("Reader connected");
               var completed = false;
               while (!completed)
               {
                  var line = await reader.ReadLineAsync().ConfigureAwait(false);
                  WriteLine(line);
                  if (line == "bye")
                  {
                     completed = true;
                  }
               }
            }

            WriteLine("completed reading");
            ReadLine();
         }
         catch (Exception ex)
         {
            WriteLine(ex);
         }
      }
   }
}