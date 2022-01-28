using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace AnonymousPipesSample
{
   public static class AnonymousPipeEntry
   {
      private static string _pipeHandle;
      private static ManualResetEventSlim _pipeHandleSet;

      public static void Main()
      {
         Run();
         ReadLine();
      }

      private static void Run()
      {
         _pipeHandleSet = new ManualResetEventSlim(false);

         Task.Run(() => Reader());
         Task.Run(() => Writer());
      }

      private static void Reader()
      {
         try
         {
            WriteLine("Anonymous pipe reader");
            using (var pipeReader = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.None))
            using (var reader = new StreamReader(pipeReader))
            {
               _pipeHandle = pipeReader.GetClientHandleAsString();
               WriteLine($"Pipe handle: {_pipeHandle}");
               _pipeHandleSet.Set();
               var end = false;
               while (!end)
               {
                  var line = reader.ReadLine();
                  WriteLine(line);
                  if (line == "end")
                  {
                     end = true;
                  }
               }

               WriteLine("Finished reading");
            }
         }
         catch (Exception ex)
         {
            WriteLine(ex.Message);
         }
      }

      private static void Writer()
      {
         WriteLine("Anonymous pipe writer");
         _pipeHandleSet.Wait();

         using (var pipeWriter = new AnonymousPipeClientStream(PipeDirection.Out, _pipeHandle))
         using (var writer = new StreamWriter(pipeWriter) {AutoFlush = true})
         {
            WriteLine("Starting writer");
            for (var i = 0; i < 5; i++)
            {
               writer.WriteLine($"Message {i}");
               Task.Delay(500).Wait();
            }

            writer.WriteLine("end");
         }
      }
   }
}