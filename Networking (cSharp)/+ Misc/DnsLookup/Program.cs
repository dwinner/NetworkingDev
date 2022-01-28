/**
 * Преобразование доменных имен и IP-адресов
 */

using System;
using System.Windows.Forms;

namespace DnsLookup
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new DnsLookupForm());
      }
   }
}
