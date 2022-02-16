using System;
using System.Web.UI;
using WebService.Simple.Consuming.SimpleService;

namespace WebService.Simple.Consuming
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected void TriggerButton_OnClick(object sender, EventArgs e)
      {
         var soapClient = new SimpleServiceSoapClient();
         ResultLabel.Text = soapClient.CanWeFixIt();
      }
   }
}