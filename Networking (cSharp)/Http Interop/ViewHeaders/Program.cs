/**
 * Просмотр заголовков ответа
 */

using System;
using System.Windows.Forms;

namespace ViewHeaders
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new ViewHeadersForm());
      }
   }
}
