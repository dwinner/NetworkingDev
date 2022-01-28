using System;
using System.Windows.Forms;

namespace WebBrowser
{
   public partial class WebBrowserForm : Form
   {
      public WebBrowserForm()
      {
         InitializeComponent();
      }

      private void goButton_Click(object sender, EventArgs e)
      {
         if (urlRadioButton.Checked)
         {
            ieWebBrowser.Navigate(urlTextBox.Text);
         }
         else
         {
            ieWebBrowser.DocumentText = htmlTextBox.Text;
         }
      }

      private void OnRadioCheckedChanged(object sender, EventArgs e)
      {
         urlTextBox.Enabled = urlRadioButton.Checked;
         htmlTextBox.Enabled = htmlRadioButton.Checked;
      }
   }
}
