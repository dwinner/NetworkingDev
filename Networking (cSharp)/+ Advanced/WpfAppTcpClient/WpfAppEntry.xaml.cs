using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using TcpServerSample;

namespace WpfAppTcpClient
{
   public partial class WpfAppEntry : INotifyPropertyChanged, IDisposable
   {
      private readonly CustomProtocolCommands _commands = new CustomProtocolCommands();
      private TcpClient _client = new TcpClient();

      public WpfAppEntry()
      {
         InitializeComponent();
      }

      public IEnumerable<CustomProtocolCommand> Commands => _commands;

      public void Dispose() => _client?.Close();

      private void ParseMessage(string message)
      {
         if (string.IsNullOrEmpty(message))
         {
            return;
         }

         var messageColl = message.Split(
            new[] {CustomProtocol.Separator}, StringSplitOptions.RemoveEmptyEntries);
         Status = messageColl[0];
         SessionId = GetSessionId(messageColl);
      }

      private static string GetSessionId(IReadOnlyList<string> messageColl)
         => messageColl.Count >= 2 && messageColl[1] == "ID" ? messageColl[2] : string.Empty;

      private bool VerifyIsConnected()
      {
         if (!_client.Connected)
         {
            MessageBox.Show("Connect first");
            return false;
         }

         return true;
      }

      private string GetSessionHeader()
         => string.IsNullOrEmpty(SessionId) ? string.Empty : $"ID::{SessionId}";

      private string GetCommand()
         => $"{GetSessionHeader()}{ActiveCommand?.Name}::{ActiveCommand?.Action}";

      #region Event handlers

      private async void OnConnect(object sender, RoutedEventArgs e)
      {
         try
         {
            await _client.ConnectAsync(RemoteHost, ServerPort).ConfigureAwait(true);
         }
         catch (SocketException socketEx) when (socketEx.ErrorCode == 0x2748)
         {
            _client.Close();
            _client = new TcpClient();
            MessageBox.Show("Please retry connect");
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private async void OnSendCommand(object sender, RoutedEventArgs e)
      {
         const int bufferSize = 1024;

         try
         {
            if (!VerifyIsConnected())
            {
               return;
            }

            using (var stream = _client.GetStream())
            {
               var writeBuffer = Encoding.ASCII.GetBytes(GetCommand());
               await stream.WriteAsync(writeBuffer, 0, writeBuffer.Length).ConfigureAwait(true);
               await stream.FlushAsync().ConfigureAwait(true);
               var readBuffer = new byte[bufferSize];
               var read = await stream.ReadAsync(readBuffer, 0, readBuffer.Length).ConfigureAwait(true);
               var readMessage = Encoding.ASCII.GetString(readBuffer, 0, read);
               Log += readMessage + Environment.NewLine;
               ParseMessage(readMessage);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void OnClearLog(object sender, RoutedEventArgs e)
         => Log = string.Empty;

      #endregion

      #region Properties

      private string _remoteHost = "localhost";

      public string RemoteHost
      {
         get => _remoteHost;
         set => SetProperty(ref _remoteHost, value, nameof(RemoteHost));
      }

      private int _serverPort = 8800;

      public int ServerPort
      {
         get => _serverPort;
         set => SetProperty(ref _serverPort, value);
      }

      private string _sessionId;

      public string SessionId
      {
         get => _sessionId;
         set => SetProperty(ref _sessionId, value);
      }

      private CustomProtocolCommand _activeCommand;

      public CustomProtocolCommand ActiveCommand
      {
         get => _activeCommand;
         set => SetProperty(ref _activeCommand, value);
      }

      private string _log;

      public string Log
      {
         get => _log;
         set => SetProperty(ref _log, value);
      }

      public string Status { get; set; }

      #endregion

      #region INotifyPropertyChanged

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged(string propertyName)
         => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

      private bool SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
      {
         if (EqualityComparer<T>.Default.Equals(item, value))
         {
            return false;
         }

         item = value;
         OnPropertyChanged(propertyName);
         return true;
      }

      #endregion
   }
}