using System;
using System.Windows.Forms;

namespace IPv6Multicast
{
    internal static class App
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}