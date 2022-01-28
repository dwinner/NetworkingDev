using System;
using System.Reactive.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SearchingWikipedia
{
   public partial class MainWindow
   {
      public MainWindow()
      {
         InitializeComponent();         

         var keys =
            Observable.FromEventPattern<KeyEventArgs>(SearchTextBox, nameof(KeyUp)).Throttle(TimeSpan.FromSeconds(.5));
         keys.ObserveOn(SynchronizationContext.Current).Subscribe(evt =>
         {
            ProgressTextBlock.Text = $"Searching for...{SearchTextBox.Text}";
            ProgressTextBlock.Visibility = Visibility.Visible;
            ResultWebBrowser.Navigate(new Uri($"http://en.wikipedia.org/wiki/{SearchTextBox.Text}"));
         });

         var browser = Observable.FromEventPattern<NavigationEventArgs>(ResultWebBrowser, nameof(WebBrowser.Navigated));
         browser.ObserveOn(SynchronizationContext.Current)
            .Subscribe(evt => ProgressTextBlock.Visibility = Visibility.Collapsed);
      }
   }
}