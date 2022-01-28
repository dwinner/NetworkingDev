using System;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace WinForms.Persistent.Client
{
   public partial class PersistentForm : Form
   {
      private readonly Connection _persistentConnection=new Connection("http://localhost:4081/SamplePC/");

      public PersistentForm()
      {
         InitializeComponent();
         _persistentConnection.Received += OnReceived;
         _persistentConnection.Start();
      }

      private void OnReceived(string obj)
      {
         MessageListBox.Invoke(new Action(() =>
         {
            MessageListBox.Items.Add(obj);
         }));
      }

      private void SendButton_Click(object sender, System.EventArgs e)
      {
         _persistentConnection.Send(string.Format("{0}:{1}", UserTextBox.Text, MessageTextBox.Text));
      }
   }
}