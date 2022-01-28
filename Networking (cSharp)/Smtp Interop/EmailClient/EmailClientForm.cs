using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using EmailClient.Properties;

namespace EmailClient
{
   public partial class EmailClientForm : Form
   {
      public EmailClientForm()
      {
         InitializeComponent();
      }

      private void buttonAttachFile_Click(object sender, EventArgs e)
      {
         OpenFileDialog fileDialog = new OpenFileDialog { Multiselect = true };
         if (fileDialog.ShowDialog() != DialogResult.OK)
            return;
         foreach (string file in fileDialog.FileNames)
         {
            ListViewItem item = new ListViewItem(file);
            FileInfo info = new FileInfo(file);
            item.SubItems.Add(string.Format("{0:N0}KB", info.Length / 1024));
            filesListView.Items.Add(item);
         }
      }

      private void filesListView_OnKeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.Delete:
               if (filesListView.SelectedItems.Count > 0)
               {
                  List<ListViewItem> itemsToDelete = filesListView.SelectedItems.Cast<ListViewItem>().ToList();

                  foreach (ListViewItem item in itemsToDelete)
                  {
                     item.Remove();
                  }
               }
               break;
         }
      }

      private void buttonSend_Click(object sender, EventArgs e)
      {
         List<string> attachments = (from ListViewItem item in filesListView.Items
                                     select item.Text).ToList();

         try
         {
            SendEmail(hostnameTextBox.Text, (int)portNumericUpDown.Value,
                usernameTextBox.Text, passwordTextBox.Text,
                fromTextBox.Text, toTextBox.Text,
                subjectTextBox.Text, bodyTextBody.Text,
                attachments);
            MessageBox.Show(Resources.MessageSent);
         }
         catch (SmtpException ex)
         {
            MessageBox.Show(Resources.ErrorSendingEmail + ex.Message);
         }
      }

      private static void SendEmail(string host,
                              int port,
                              string username,
                              string password,
                              string from,
                              string to,
                              string subject,
                              string body,
                              IEnumerable<string> attachedFiles)
      {
         using (MailMessage message = new MailMessage()) // Объект MailMessage должен быть уничтожен
         {
            message.From = new MailAddress(from);
            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;
            foreach (string file in attachedFiles)
            {
               message.Attachments.Add(new Attachment(file));
            }

            // Если SMTP-сервер требует пароль, нужно добавить объект учетной записи Credentials
            SmtpClient client = new SmtpClient(host, port)
               {
                  Credentials = new NetworkCredential(username, password)
               };
            client.Send(message);   // Синхронная отправка сообщения. Note: Можно сделать ее асинхронной!
         }
      }
   }
}
