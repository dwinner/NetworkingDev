using System;
using System.Windows.Forms;
using RssLib;
using RssReader.Properties;

namespace RssReader
{
   public partial class RssReaderForm : Form
   {
      readonly Feed _feed = new Feed();

      public RssReaderForm()
      {
         InitializeComponent();

         feedTextBox.Text = @"http://feeds.feedburner.com/PhilosophicalGeek";
         LoadFeed(feedTextBox.Text);
      }

      private void loadButton_Click(object sender, EventArgs e)
      {
         LoadFeed(feedTextBox.Text);
      }

      private void LoadFeed(string url)
      {
         entriesListView.Items.Clear();

         Channel channel = _feed.Read(url);
         Text = Resources.RssReaderForm_LoadFeed_RSS_Reader + channel.Title;

         foreach (Item item in channel.Items)
         {
            ListViewItem listViewItem = new ListViewItem(item.PubDate);
            listViewItem.SubItems.Add(item.Title);
            listViewItem.SubItems.Add(item.Link);
            listViewItem.Tag = item;
            entriesListView.Items.Add(listViewItem);
         }
      }

      private void OnSelectListViewItem(object sender, EventArgs e)
      {
         if (entriesListView.SelectedItems.Count <= 0)
            return;
         Item item = entriesListView.SelectedItems[0].Tag as Item;
         if (item != null)         
            descriptionTextBox.Text = item.Description;         
      }
   }
}
