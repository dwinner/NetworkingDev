using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TcpSend
{
   public partial class TcpSendForm : Form
   {
      private const string FileToSend = "listen.txt";

      public TcpSendForm()
      {
         InitializeComponent();
      }

      private void SendButton_Click(object sender, EventArgs e)
      {
         try
         {
            var tcpClient = new TcpClient(HostnameTextBox.Text, Int32.Parse(PortTextBox.Text));
            NetworkStream networkStream = tcpClient.GetStream();
            FileStream fileStream = File.Open(FileToSend, FileMode.Open);
            int currentData = fileStream.ReadByte();
            while (currentData != -1)
            {
               networkStream.WriteByte((byte)currentData);
               currentData = fileStream.ReadByte();
            }
            fileStream.Close();
            networkStream.Close();
            tcpClient.Close();
         }
         catch (SocketException socketEx)
         {
            MessageBox.Show(socketEx.Message);
         }
      }
   }
}
