/**
 * Клиент TCP
 */

using System;
using System.Windows.Forms;

namespace TcpSend
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new TcpSendForm());
      }
   }
}
