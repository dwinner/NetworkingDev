/**
 * Простейший пример браузера
 */

using System;
using System.Windows.Forms;

namespace SimpleBrowserSample
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new BrowserForm());
      }
   }
}
