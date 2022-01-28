/**
 * Простейший клиент на базе сокетов
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
   class ClientEntryPointProgram
   {
      private const string Host = "127.0.0.1";
      private const int Port = 2112;

      static void Main()
      {
         var receivedBytes = new byte[1024];
#pragma warning disable 618
         IPHostEntry ipHost = Dns.Resolve(Host);
#pragma warning restore 618
         IPAddress ipAddress = ipHost.AddressList[0];
         var ipEndPoint = new IPEndPoint(ipAddress, Port);
         Console.WriteLine("Starting: Creating Socket Object");   // Создание объекта Socket

         using (var senderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
         {
            senderSocket.Connect(ipEndPoint);
            Console.WriteLine("Successfully connected to {0}", senderSocket.RemoteEndPoint);
            const string sendingMessage = "Hello, Socket Test";
            Console.WriteLine("Creating message: {0}", sendingMessage); // Создание сообщения
            byte[] forwardMessage = Encoding.ASCII.GetBytes(string.Format("{0}[FINAL]", sendingMessage));
            senderSocket.Send(forwardMessage);
            int totalBytesReceived = senderSocket.Receive(receivedBytes);
            Console.WriteLine("Message provided from server: {0}",
               Encoding.ASCII.GetString(receivedBytes, 0, totalBytesReceived));
            senderSocket.Shutdown(SocketShutdown.Both);
         }

         Console.ReadLine();
      }
   }
}
