using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WebRequestClient.Annotations;

namespace WebRequestClient
{
   /// <summary>
   ///    Приложение клиента HTTP
   /// </summary>
   public partial class MainWindow : INotifyPropertyChanged
   {
      private const string DefaultRequest = "http://localhost/Samples/Menus";
      private bool? _jsonRequest;

      private string _result;

      private string _urlRequest;

      public MainWindow()
      {
         InitializeComponent();
         UrlRequest = DefaultRequest;
         JsonRequest = false;
         DataContext = this;
      }

      public string Result
      {
         get { return _result; }
         set { SetProperty(ref _result, value); }
      }

      public string UrlRequest
      {
         get { return _urlRequest; }
         set { SetProperty(ref _urlRequest, value); }
      }

      public bool? JsonRequest
      {
         get { return _jsonRequest; }
         set { SetProperty(ref _jsonRequest, value); }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
      {
         if (!EqualityComparer<T>.Default.Equals(field, value))
         {
            field = value;
            OnPropertyChanged(propertyName);
         }
      }

      private async void CallDataServiceButton_OnClick(object sender, RoutedEventArgs e)
      {
         Cursor oldCursor = Cursor;
         try
         {
            Result = string.Empty;
            Cursor = Cursors.Wait;

            using (var client = new HttpClient())
            {
               if (JsonRequest == true)
               {
                  client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
               }

               using (HttpResponseMessage response = await client.GetAsync(UrlRequest))
               {
                  Result = await response.Content.ReadAsStringAsync();
               }
            }
         }
         catch (HttpRequestException ex)
         {
            Result = ex.Message;
         }
         catch (UriFormatException ex)
         {
            Result = ex.Message;
         }
         finally
         {
            Cursor = oldCursor;
         }
      }

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}