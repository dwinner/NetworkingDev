using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace P2PSample
{
   /// <summary>
   ///    Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow
   {
      private readonly ObservableCollection<PeerEntry> _peerList = new ObservableCollection<PeerEntry>();
      private readonly object _peersLock = new object();
      private ServiceHost _host;
      private IPeerToPeerService _localService;
      private PeerName _peerName;
      private PeerNameRegistration _peerNameRegistration;

      public MainWindow()
      {
         InitializeComponent();
         DataContext = this;
         _peerList.Add(new PeerEntry
         {
            DisplayString = "Refresh to look for peers.",
            ButtonsEnabled = false
         });
         BindingOperations.EnableCollectionSynchronization(_peerList, _peersLock);
      }

      protected override void OnClosing(CancelEventArgs e)
      {
         // Остановить регистрацию
         _peerNameRegistration.Stop();
         _peerNameRegistration.Dispose();

         // Остановить WCF-сервис
         if (_host.State == CommunicationState.Opened)
         {
            _host.Close();
         }

         base.OnClosing(e);
      }

      private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
      {
         // Получение конфигурационной информации из App.config
         string port = ConfigurationManager.AppSettings["port"];
         string username = ConfigurationManager.AppSettings["username"];
         string machineName = Environment.MachineName;

         // Установка заголовка окна
         Title = string.Format("{0}: P2P example - {1}", machineName, username);

         // Получение URL-адреса службы с использованием адреса IPv4 и порта из конфигурационного файла
         string serviceUrl = Dns.GetHostAddresses(Dns.GetHostName())
            .Where(address => address.AddressFamily == AddressFamily.InterNetwork)
            .Select(address => string.Format("net.tcp://{0}:{1}/PeerToPeerService", address, port))
            .FirstOrDefault();

         // Выполнение проверки, не является ли адрес нулевым
         if (serviceUrl == null)
         {
            // Отображение ошибки и завершение работы приложения
            MessageBox.Show(this, "Unable to determine WCF endpoint.", "Networking Error", MessageBoxButton.OK,
               MessageBoxImage.Stop);
            Application.Current.Shutdown();
            return;
         }

         // Регистрация и запуск службы WCF
         _localService = new PeerToPeerService(this, username);
         _host = new ServiceHost(_localService, new Uri(serviceUrl));
         var binding = new NetTcpBinding { Security = { Mode = SecurityMode.None } };
         _host.AddServiceEndpoint(typeof(IPeerToPeerService), binding, serviceUrl);

         try
         {
            _host.Open();
         }
         catch (AddressAlreadyInUseException)
         {
            // Отображение ошибки и завершение работы приложения
            MessageBox.Show(this, "Cannot start listening, port in use", "WCF Error", MessageBoxButton.OK,
               MessageBoxImage.Stop);
            Application.Current.Shutdown();
         }

         // Создание имени равноправного участника
         _peerName = new PeerName("P2P Sample", PeerNameType.Unsecured);

         // Подготовка регистрации имени равноправного участника в облаке локального соединения
         _peerNameRegistration = new PeerNameRegistration(_peerName, int.Parse(port)) { Cloud = Cloud.AllLinkLocal };

         // Начало регистрации
         _peerNameRegistration.Start();
      }

      private async void RefreshButton_OnClick(object sender, RoutedEventArgs e)
      {
         // Создание распознавателя и добавление обработчиков событий
         var resolver = new PeerNameResolver();
         resolver.ResolveProgressChanged += Resolver_ResolveProgressChanged;
         resolver.ResolveCompleted += Resolver_ResolveCompleted;

         // Подготовка новых равноправных участников
         _peerList.Clear();
         RefreshButton.IsEnabled = false;

         // Распознавание незащищенных равноправных участников асинхронным образом
         resolver.ResolveAsync(new PeerName("0.P2P Sample"), 1);

         await Task.Delay(5000); // NOTE: Для вызова события ResolveCompleted после максимум 5 секунд
         resolver.ResolveAsyncCancel(1);
      }

      private void Resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
      {
         if (_peerList.Count == 0)
         {
            lock (_peersLock)
            {
               _peerList.Add(new PeerEntry
               {
                  DisplayString = "No peers found.",
                  ButtonsEnabled = false
               });
            }
         }

         RefreshButton.IsEnabled = true;
      }

      private void Resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
      {
         PeerNameRecord peer = e.PeerNameRecord;
         peer.EndPointCollection.Where(point => point.Address.AddressFamily == AddressFamily.InterNetwork)
            .AsParallel()
            .ForAll(
               point =>
               {
                  try
                  {
                     string endpointUrl = string.Format("net.tcp://{0}:{1}/PeerToPeerService", point.Address, point.Port);
                     var binding = new NetTcpBinding { Security = { Mode = SecurityMode.None } };
                     IPeerToPeerService serviceProxy = ChannelFactory<IPeerToPeerService>.CreateChannel(binding,
                        new EndpointAddress(endpointUrl));

                     lock (_peersLock)
                     {
                        _peerList.Add(new PeerEntry
                        {
                           PeerName = peer.PeerName,
                           ServiceProxy = serviceProxy,
                           DisplayString = serviceProxy.GetName(),
                           ButtonsEnabled = true
                        });
                     }
                  }
                  catch (EndpointNotFoundException)
                  {
                     lock (_peersLock)
                     {
                        _peerList.Add(new PeerEntry
                        {
                           PeerName = peer.PeerName,
                           DisplayString = "Unknown peer",
                           ButtonsEnabled = false
                        });
                     }
                  }
               });
      }

      private void OnPeerListClick(object sender, RoutedEventArgs e)
      {
         var messageButton = e.OriginalSource as Button;
         if (messageButton != null && messageButton.Name == "MessageButton")
         {
            var peerEntry = messageButton.DataContext as PeerEntry;
            if (peerEntry != null && peerEntry.ServiceProxy != null)
            {
               try
               {
                  peerEntry.ServiceProxy.SendMessage("Hi there!", ConfigurationManager.AppSettings["username"]);
               }
               catch (CommunicationException)
               {
               }
            }
         }
      }

      public void DisplayMessage(string message, string @from)
      {
         MessageBox.Show(this, message, string.Format("Message from {0}", from), MessageBoxButton.OK,
            MessageBoxImage.Information);
      }
   }
}