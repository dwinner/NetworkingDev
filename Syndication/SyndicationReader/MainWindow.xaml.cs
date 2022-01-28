using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows;
using System.Xml;

namespace SyndicationReader
{
   /// <summary>
   ///    Чтение синдицируемых каналов
   /// </summary>
   public partial class MainWindow
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void OnGetFeed(object sender, RoutedEventArgs e)
      {
         using (XmlReader reader = XmlReader.Create(UrlTextBox.Text))
         {
            var formatter = new Rss20FeedFormatter();
            formatter.ReadFrom(reader);
            DataContext = formatter.Feed;
            FeedContentPanel.DataContext = formatter.Feed.Items;

            IEnumerable<SyndicationItem> syndicationItems = formatter.Feed.Items;
            if (TitleListBox.Items.Count > 0)
               TitleListBox.Items.Clear();

            foreach (var syndicationItem in syndicationItems)
               TitleListBox.Items.Add(syndicationItem.Title.Text);
         }
      }
   }
}