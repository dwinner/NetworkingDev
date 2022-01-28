using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System.Xml.Linq;
using ReactiveUI;
using ReactiveUI.Legacy;
using ReactiveCommandMixins = ReactiveUI.ReactiveCommandMixins;

namespace FlickrSearch.RxUI.Model
{
   public class AppViewModel : ReactiveObject
   {
      private readonly ObservableAsPropertyHelper<Visibility> _spinnerVisibility;
      private readonly ObservableAsPropertyHelper<List<FlickrPhoto>> _searchResults;
      private string _searchTerm;

      public AppViewModel(ReactiveAsyncCommand reactiveAsyncCommand = null,
         IObservable<List<FlickrPhoto>> searchResults = null)
      {
         ExecuteSearch = reactiveAsyncCommand ?? new ReactiveAsyncCommand();
         ReactiveCommandMixins.InvokeCommand(this.ObservableForProperty(model => model.SearchTerm)
            .Throttle(TimeSpan.FromMilliseconds(800), RxApp.TaskpoolScheduler)
            .Select(x => x.Value)
            .DistinctUntilChanged()
            .Where(x => !string.IsNullOrWhiteSpace(x)), ExecuteSearch);
         _spinnerVisibility =
            ExecuteSearch.ItemsInflight.Select(x => x > 0 ? Visibility.Visible : Visibility.Collapsed)
               .ToProperty(this, model => model.SpinnerVisibility, Visibility.Hidden);
         var results = searchResults ??
                       ExecuteSearch.RegisterAsyncFunction(term => GetSearchResultFromFlickr((string)term));
         _searchResults = results.ToProperty(this, model => model.SearchResults, new List<FlickrPhoto>());
      }

      public string SearchTerm
      {
         get { return _searchTerm; }
         set { this.RaiseAndSetIfChanged(ref _searchTerm, value); }
      }

      public ReactiveAsyncCommand ExecuteSearch { get; }

      public List<FlickrPhoto> SearchResults => _searchResults.Value;

      public Visibility SpinnerVisibility => _spinnerVisibility.Value;

      private static List<FlickrPhoto> GetSearchResultFromFlickr(string searchTerm)
      {
         var doc =
            XDocument.Load(string.Format(CultureInfo.InvariantCulture,
               "http://api.flickr.com/services/feeds/photos_public.gne?tags={0}&format=rss_200",
               HttpUtility.UrlEncode(searchTerm)));

         if (doc.Root == null)
         {
            return null;
         }

         var titles = doc.Root.Descendants("{http://search.yahoo.com/mrss/}title").Select(x => x.Value);
         var tagRegex = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
         var descriptions =
            doc.Root.Descendants("{http://search.yahoo.com/mrss/}description")
               .Select(x => tagRegex.Replace(HttpUtility.HtmlDecode(x.Value), ""));
         var items =
            titles.Zip(descriptions, (title, description) => new FlickrPhoto { Title = title, Description = description })
               .ToArray();
         var urls =
            doc.Root.Descendants("{http://search.yahoo.com/mrss/}thumbnail")
               .Select(x => x.Attributes("url").First().Value);
         var ret = items.Zip(urls, (item, url) =>
         {
            item.Url = url;
            return item;
         }).ToList();

         return ret;
      }
   }
}