using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BasicWebClient
{
   public partial class BasicWebClientForm : Form
   {
      private const string DestinationUri = "http://www.reuters.com";

      public BasicWebClientForm()
      {
         InitializeComponent();

         var client = new WebClient();
         using (Stream stream = client.OpenRead(DestinationUri))
         {
            if (stream != null)
            {
               using (var reader = new StreamReader(stream))
               {
                  string line;
                  while ((line = reader.ReadLine()) != null)
                  {
                     WebContentListBox.Items.Add(line);
                  }
               }
            }
         }
      }
   }
}
