using System.Net;
using System.Windows.Forms;

namespace ViewHeaders
{
   public partial class ViewHeadersForm : Form
   {
      public ViewHeadersForm()
      {
         InitializeComponent();
      }

      private void ViewHeadersFormOnLoad(object sender, System.EventArgs e)
      {
         WebRequest webRequest = WebRequest.Create("http://www.rotapost.ru/");
         WebResponse response = webRequest.GetResponse();
         WebHeaderCollection headerCollection = response.Headers;
         for (int i = 0; i < headerCollection.Count; i++)
         {
            ViewHeadersListBox.Items.Add(
               string.Format("Header {0}: {1}", headerCollection.GetKey(i), headerCollection[i]));
         }
      }
   }
}
