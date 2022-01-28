using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TcpReceive
{
   public partial class TcpReceiveForm : Form
   {
      private const string ListenAddress = "127.0.0.1";
      private const int ListenPort = 2112;

      protected delegate void UpdateDisplayDelegate(string text);

      public TcpReceiveForm()
      {
         InitializeComponent();
         var socketThread = new Thread(async () =>
         {
            var localAddress = IPAddress.Parse(ListenAddress);
            var tcpListener = new TcpListener(localAddress, ListenPort);
            tcpListener.Start();
            TcpClient acceptedClient = await tcpListener.AcceptTcpClientAsync();
            using (var networkStream = acceptedClient.GetStream())
            using (var streamReader = new StreamReader(networkStream))
            {
               string result = await streamReader.ReadToEndAsync();
               Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { result });
            }

            acceptedClient.Close();
            tcpListener.Stop();
         });
         socketThread.Start();
      }

      private void UpdateDisplay(string text)
      {
         IncomingTextBox.Text = text;
      }
   }
}
