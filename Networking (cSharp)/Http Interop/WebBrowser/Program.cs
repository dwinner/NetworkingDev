/**
 * Встраивание веб-браузера в приложение
 */

using System;
using System.Windows.Forms;

namespace WebBrowser
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new WebBrowserForm());
      }
   }
}
