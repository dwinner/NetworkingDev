/**
 * Отправка почты по протоколу SMTP
 */

using System;
using System.Windows.Forms;

namespace EmailClient
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new EmailClientForm());
      }
   }
}
