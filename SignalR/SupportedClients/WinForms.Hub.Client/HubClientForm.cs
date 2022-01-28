using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;

namespace WinForms.Hub.Client
{
   public partial class HubClientForm : Form
   {
      private IHubProxy _auctionProxy;
      private HubConnection _hubConnection;
      private UpdateButtons _updateButtonsDelegate;

      private UpdateBid _updateDelegate;

      public HubClientForm()
      {
         InitializeComponent();
         SetupHub();
      }

      private async void SetupHub()
      {
         _updateDelegate = UpdateBidMethod;
         _updateButtonsDelegate = UpdateButtonsMethod;
         _hubConnection = new HubConnection("http://localhost:4558");
         _auctionProxy = _hubConnection.CreateHubProxy("AuctionHub");
         _auctionProxy.Subscribe("updateBid").Received += OnUpdateBid;
         _auctionProxy.Subscribe("CloseBid").Received += OnCloseBid;
         _auctionProxy.Subscribe("CloseBidWin").Received += OnCloseBidWin;

         await _hubConnection.Start().ConfigureAwait(false);
      }

      private void OnCloseBidWin(IList<JToken> obj)
      {
         Invoke(_updateButtonsDelegate, false);
         Invoke(_updateDelegate, obj[0], 1);
      }

      private void OnCloseBid(IList<JToken> obj)
      {
         Invoke(_updateButtonsDelegate, false);
      }

      private void OnUpdateBid(IList<JToken> obj)
      {
         Invoke(_updateDelegate, obj[0], 0);
         Invoke(_updateButtonsDelegate, true);
      }

      private void UpdateButtonsMethod(bool enabled)
      {
         CurrentBidButton.Enabled = enabled;
         MakeBidButton.Enabled = enabled;
      }

      private void UpdateBidMethod(dynamic bid, int formobject)
      {
         if (bid != null)
         {
            NameLabel.Text = bid.Name;
            DescriptionLabel.Text = bid.Description;
            BidLabel.Text = bid.BidPrice;
            TimeValueLabel.Text = bid.TimeLeft;
            if (formobject > 0)
            {
               WinsListBox.Items.Add(bid.Name + " at " + bid.BidPrice);
            }
         }
      }

      private void CurrentBidButton_Click(object sender, EventArgs e)
      {
         _auctionProxy.Invoke("MakeCurrentBid");
      }

      private void MakeBidButton_Click(object sender, EventArgs e)
      {
         _auctionProxy.Invoke<string>("MakeBid", BidTextBox.Text);
      }

      private delegate void UpdateBid(dynamic bid, int formObject);

      private delegate void UpdateButtons(bool enabled);
   }
}