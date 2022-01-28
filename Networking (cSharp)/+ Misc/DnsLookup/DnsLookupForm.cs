using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DnsLookup
{
   public partial class DnsLookupForm : Form
   {
      public DnsLookupForm()
      {
         InitializeComponent();
      }

      private async void ResolveButton_Click(object sender, System.EventArgs e)
      {
         try
         {
            IPHostEntry ipHostEntry = await Dns.GetHostEntryAsync(DnsInputTextBox.Text);
            foreach (IPAddress ipAddress in from ipAddress in ipHostEntry.AddressList
                                            let ipaddress = ipAddress.AddressFamily.ToString()
                                            select ipAddress)
            {
               IpAddressesListBox.Items.Add(ipAddress);
            }

            HostNameTextBox.Text = ipHostEntry.HostName;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
