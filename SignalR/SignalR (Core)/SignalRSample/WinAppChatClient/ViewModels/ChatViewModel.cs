using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WinAppChatClient.Services;

namespace WinAppChatClient.ViewModels
{
   public class ChatViewModel : ObservableObject
   {
      private readonly IDialogService _dialogService;
      private readonly UrlService _urlService;

      private HubConnection? _hubConnection;

      public ChatViewModel(IDialogService dialogService, UrlService urlService)
      {
         _dialogService = dialogService;
         _urlService = urlService;

         ConnectCommand = new RelayCommand(OnConnect);
         SendCommand = new RelayCommand(OnSendMessage);
      }

      public string? Name { get; set; }
      public string? Message { get; set; }

      public ObservableCollection<string> Messages { get; } = new();

      public RelayCommand SendCommand { get; }

      public RelayCommand ConnectCommand { get; }

      public async void OnConnect()
      {
         await CloseConnectionAsync().ConfigureAwait(false);
         _hubConnection = new HubConnectionBuilder()
            .WithUrl(_urlService.ChatAddress)
            .Build();

         _hubConnection.Closed += HubConnectionClosed;
         _hubConnection.On<string, string>("BroadcastMessage", OnMessageReceived);

         try
         {
            await _hubConnection.StartAsync().ConfigureAwait(false);
            await _dialogService.ShowMessageAsync("client connected").ConfigureAwait(true);
         }
         catch (HttpRequestException ex)
         {
            await _dialogService.ShowMessageAsync(ex.Message).ConfigureAwait(true);
         }
      }

      private Task HubConnectionClosed(Exception arg)
         => _dialogService.ShowMessageAsync("Hub connection closed");

      public async void OnSendMessage()
      {
         try
         {
            await _hubConnection.SendAsync("Send", Name, Message).ConfigureAwait(true);
         }
         catch (Exception ex)
         {
            await _dialogService.ShowMessageAsync(ex.Message).ConfigureAwait(true);
         }
      }

      public async void OnMessageReceived(string name, string message)
      {
         try
         {
            Messages.Add($"{name}: {message}");
            //_dispatcherQueue.DispatcherQueue.TryEnqueue(() =>
            //{
            //    Messages.Add($"{name}: {message}");
            //});
            //await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            //    Messages.Add($"{name}: {message}");
            //});
         }
         catch (Exception ex)
         {
            await _dialogService.ShowMessageAsync(ex.Message).ConfigureAwait(true);
         }
      }

      private ValueTask CloseConnectionAsync()
         => _hubConnection?.DisposeAsync() ?? ValueTask.CompletedTask;
   }
}