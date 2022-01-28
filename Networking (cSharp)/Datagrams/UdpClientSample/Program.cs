/**
 * Дейтаграмный клиент
 * NOTE: Включи ECHO-сервер Windows
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpClientSample
{
   internal static class Program
   {
      private static void Main()
      {
         try
         {
            var udpClient = new UdpClient();
            const string sendMessage = "Hello, Echo Server";
            var sendBytes = Encoding.ASCII.GetBytes(sendMessage);
            udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", 7);
            var endPoint = new IPEndPoint(0, 0);
            var rcvBytes = udpClient.Receive(ref endPoint);
            var rcvMessage = Encoding.ASCII.GetString(rcvBytes, 0, rcvBytes.Length);
            // Должна быть выведена строка Hello, Echo Server
            Console.WriteLine(rcvMessage);
         }
         catch (SocketException socketEx)
         {
            Console.WriteLine(socketEx);
         }
      }
   }
}