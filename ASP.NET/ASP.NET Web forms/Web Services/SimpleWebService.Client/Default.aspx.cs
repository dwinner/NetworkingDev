using System;
using System.Web.UI;
using SimpleWebService.Client.SimpleWebServiceReference;

namespace SimpleWebService.Client
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected void TriggerButton_OnClick(object sender, EventArgs e)
      {
         var client = new SimpleWebServiceSoapClient();
         string canWeFixIt = client.CanWeFixIt();
         ResultLabel.Text = canWeFixIt;
      }
   }
}