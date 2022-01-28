using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WCFClient
{
   public partial class WcfClientForm : Form
   {
      private readonly FileServiceClient _fileServiceClient;

      public WcfClientForm()
      {
         InitializeComponent();

         _fileServiceClient = new FileServiceClient();
      }

      private void buttonGetSubDirs_Click(object sender, EventArgs e)
      {
         SetResults(_fileServiceClient.GetSubDirectories(getSubDirsTextBox.Text));
      }

      private void buttonGetFiles_Click(object sender, EventArgs e)
      {
         SetResults(_fileServiceClient.GetFiles(getFilesTextBox.Text));
      }

      private void buttonGetFileContents_Click(object sender, EventArgs e)
      {
         var bytesToRead = (int) bytesToReadNumericUpDown.Value;
         byte[] buffer;
         var bytesRead = _fileServiceClient.RetrieveFile(out buffer, retrieveFileTextBox.Text, bytesToRead);

         if (bytesRead > 0)
         {
            // В этом примере предполагается кодировка ASCII
            var text = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            SetResults(text);
         }
      }

      private void SetResults(IEnumerable<string> results)
      {
         // LINQ без труда позволяет конкатенировать результаты
         textBoxOutput.Text = results.Aggregate((a, b) => a + Environment.NewLine + b);
      }

      private void SetResults(string results)
      {
         textBoxOutput.Text = results;
      }
   }
}