using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using BingSearch.Frontend.ServiceReference1;

namespace BingSearch.Frontend
{
   public partial class MainWindow
   {
      public MainWindow()
      {
         InitializeComponent();

         var clickObservable = new Subject<RoutedEventArgs>();
         SearchButton.Click += (o, e) => clickObservable.OnNext(e);

         var searchTermObservable =
            clickObservable.Select(args => SearchBox.Text).Where(term => !string.IsNullOrWhiteSpace(term));
         searchTermObservable.Subscribe(term => ImagesToDisplay.Clear());
         var bitmapImagesToAdd =
            searchTermObservable.SelectMany(SearchBingImageApi)
               .ObserveOn(SynchronizationContext.Current)
               .Select(CreateImage);
         bitmapImagesToAdd.Subscribe(image => ImagesToDisplay.Add(image));
      }

      public ObservableCollection<BitmapImage> ImagesToDisplay { get; } = new ObservableCollection<BitmapImage>();

      private IObservable<string> SearchBingImageApi(string query)
      {
         var searchRequest = new SearchRequest
         {
            AppId = App.BingSearchApiKey,
            Query = query,
            Sources = new[] { SourceType.Image }
         };
         var client = new BingPortTypeClient();
         var request1 = new SearchRequest1(searchRequest);
         var searchAsync = client.SearchAsync(request1);
         var observableResult = Observable.FromAsync(() => searchAsync);

         return observableResult.SelectMany(response => GetUrls(response.parameters).ToObservable());
      }

      private BitmapImage CreateImage(string url) => new BitmapImage(new Uri(url));

      private string[] GetUrls(SearchResponse searchResponse)
         => searchResponse.Image.Results.Select(x => x.Thumbnail.Url).ToArray();
   }
}