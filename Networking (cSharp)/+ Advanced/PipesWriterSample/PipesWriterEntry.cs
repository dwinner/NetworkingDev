/**
 * Pipe client impl
 */

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using static System.Console;

namespace PipesWriterSample
{
   public class PipesWriterEntry
   {
      public static void Main(string[] args)
      {
         var pipeName = args.Length >= 1 ? args[0] : "MyPipe";
         if (pipeName == "anon")
         {
            AnonymousWriterAsync().Wait();
         }
         else
         {
            PipesWriterAsync(pipeName).Wait();
         }
      }

      private static async Task PipesWriterAsync(string pipeName)
      {
         try
         {
            using (var pipeWriter = new NamedPipeClientStream("localhost", pipeName, PipeDirection.Out))
            using (var writer = new StreamWriter(pipeWriter))
            {
               await pipeWriter.ConnectAsync().ConfigureAwait(false);
               WriteLine("Writer connected");

               var completed = false;
               while (!completed)
               {
                  var input = ReadLine();
                  if (input == "bye")
                  {
                     completed = true;
                  }

                  await writer.WriteLineAsync(input).ConfigureAwait(false);
                  await writer.FlushAsync().ConfigureAwait(false);
               }
            }
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }

         WriteLine("completed writing");
      }

      private static async Task AnonymousWriterAsync()
      {
         WriteLine("using anonymous pipe");
         Write("pipe handle: ");
         var pipeHandle = ReadLine();
         using (var pipeWriter = new AnonymousPipeClientStream(PipeDirection.Out, pipeHandle))
         using (var writer = new StreamWriter(pipeWriter))
         {
            for (var i = 0; i < 100; i++)
            {
               await writer.WriteLineAsync($"Message {i}").ConfigureAwait(false);
               await Task.Delay(500).ConfigureAwait(false);
            }
         }
      }
   }
}