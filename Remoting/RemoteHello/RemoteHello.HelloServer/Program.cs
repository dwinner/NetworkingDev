/**
 * Регистрация каналов для удаленного объекта
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteHello.Hello;

namespace RemoteHello.HelloServer
{
   internal static class Program
   {
      private const int IpcPort = 8087;
      private const int TcpPort = 8086;
      private const int HttpPort = 8085;

      private static void Main()
      {
         // NOTE: TCP-канал
         var tcpChannel = new TcpServerChannel(TcpPort) { IsSecured = false };
         ShowChannelProperties(tcpChannel);

         // NOTE: HTTP-канал
         var httpProps = new Dictionary<string, string>
         {
            {"name", "HTTP Channel with a Binary Formatter"},
            {"priority", "15"},
            {"port", HttpPort.ToString(CultureInfo.InvariantCulture)}
         };
         var sinkProvider = new BinaryServerFormatterSinkProvider();
         var httpChannel = new HttpServerChannel(httpProps, sinkProvider);
         ShowChannelProperties(httpChannel);

         // NOTE: IPC-канал
         var ipcChannel = new IpcChannel(IpcPort.ToString(CultureInfo.InvariantCulture)) { IsSecured = false };
         ShowChannelProperties(ipcChannel);

         RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(HelloEntity),             // Тип
            "Hi",                            // Uri
            WellKnownObjectMode.SingleCall   // Режим
         );
         RemotingConfiguration.ApplicationName = "HelloApp";
         RemotingConfiguration.RegisterActivatedServiceType(typeof(HelloEntity));

         Console.WriteLine("Press return to exit");
         Console.ReadLine();
      }

      private static void ShowChannelProperties(IChannelReceiver channel)
      {
         Console.WriteLine("Name: {0}", channel.ChannelName);
         Console.WriteLine("Priority: {0}", channel.ChannelPriority);

         if (channel is TcpChannel)
         {
            var tcpChannel = channel as TcpChannel;
            Console.WriteLine("Is secured: {0}", tcpChannel.IsSecured);
         }

         if (channel is HttpServerChannel)
         {
            var httpServerChannel = channel as HttpServerChannel;
            Console.WriteLine("Scheme: {0}", httpServerChannel.ChannelScheme);
         }

         var channelDataStore = channel.ChannelData as ChannelDataStore;
         if (channelDataStore != null)
         {
            foreach (string channelUri in channelDataStore.ChannelUris)
            {
               Console.WriteLine("URI: {0}", channelUri);
            }
         }

         Console.WriteLine();
      }
   }
}