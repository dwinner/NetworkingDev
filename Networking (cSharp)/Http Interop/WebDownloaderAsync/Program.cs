/**
 * Асинхронная загрузка WEB-содержимого
 */

using System;
using System.Windows.Forms;

namespace WebDownloaderAsync
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new DownloadForm());
      }
   }
}
