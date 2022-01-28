/**
 * Запуск экземпляра Internet Explorer
 */

using System.Diagnostics;

namespace LaunchIESample
{
   class Program
   {
      static void Main()
      {
         var ieProcess = new Process
         {
            StartInfo =
            {
               FileName = "iexplore.exe",
               Arguments = "http://www.wrox.com"
            }
         };
         ieProcess.Start();
      }
   }
}
