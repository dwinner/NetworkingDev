using System;
using System.Windows.Forms;

namespace SimpleBrowserSample
{
   public partial class BrowserForm : Form
   {
      private const char EnterCharCode = (char)13;
      private const string ContactMeAddress = "http://vk.com/hi_tech_denny";

      public BrowserForm()
      {
         InitializeComponent();
      }

      private void InputUriTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == EnterCharCode)
         {
            WebBrowser.Navigate(InputUriTextBox.Text);
         }
      }

      private void ContactLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         var outerBrowser = new WebBrowser();
         outerBrowser.Navigate(ContactMeAddress, true);
      }

      private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
      {
         InputUriTextBox.Text = WebBrowser.Url.ToString();
      }

      private void BrowserForm_Load(object sender, EventArgs e)
      {
         BackButton.Enabled = false;
         ForwardButton.Enabled = false;
         StopButton.Enabled = false;
         WebBrowser.CanGoBackChanged += WebBrowser_CanGoBackChanged;
         WebBrowser.CanGoForwardChanged += WebBrowser_CanGoForwardChanged;
         WebBrowser.DocumentTitleChanged += WebBrowser_DocumentTitleChanged;
      }

      void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
      {
         Text = WebBrowser.DocumentTitle;
      }

      void WebBrowser_CanGoForwardChanged(object sender, EventArgs e)
      {
         ForwardButton.Enabled = WebBrowser.CanGoForward;
      }

      void WebBrowser_CanGoBackChanged(object sender, EventArgs e)
      {
         BackButton.Enabled = WebBrowser.CanGoBack;
      }

      private void BackButton_Click(object sender, EventArgs e)
      {
         WebBrowser.GoBack();
         InputUriTextBox.Text = WebBrowser.Url.ToString();
      }

      private void ForwardButton_Click(object sender, EventArgs e)
      {
         WebBrowser.GoForward();
         InputUriTextBox.Text = WebBrowser.Url.ToString();
      }

      private void StopButton_Click(object sender, EventArgs e)
      {
         WebBrowser.Stop();
      }

      private void HomeButton_Click(object sender, EventArgs e)
      {
         WebBrowser.GoHome();
         InputUriTextBox.Text = WebBrowser.Url.ToString();
      }

      private void RefreshButton_Click(object sender, EventArgs e)
      {
         WebBrowser.Refresh();
      }

      private void GoButton_Click(object sender, EventArgs e)
      {
         WebBrowser.Navigate(InputUriTextBox.Text);
      }

      private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
         StopButton.Enabled = false;
         BackButton.Enabled = WebBrowser.CanGoBack;
         ForwardButton.Enabled = WebBrowser.CanGoForward;
         PageSourceTextBox.Text = WebBrowser.DocumentText;
      }

      private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         StopButton.Enabled = true;
      }

      private void PrintButton_Click(object sender, EventArgs e)
      {
         WebBrowser.Print();
      }
   }
}
