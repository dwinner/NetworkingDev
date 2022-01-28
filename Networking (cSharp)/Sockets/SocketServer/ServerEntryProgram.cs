/**
 * Простейший сервер на базе сокетов
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
   class ServerEntryProgram
   {
      private const int EndPointPort = 2112;
      private const int MaxWaitingQueue = 10;
      private const int MaxInfoBlock = 0x400;

      static void Main()
      {
         Console.WriteLine("Starting: Creating Socket object");

         // Создание объекта Socket
         var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         var endPoint = new IPEndPoint(IPAddress.Any, EndPointPort);
         serverSocket.Bind(endPoint);
         serverSocket.Listen(MaxWaitingQueue);

         while (true)
         {
            // Ожидание соединения на порте EndPointPort
            Console.WriteLine("Waiting for connection on port {0}", EndPointPort);
            Socket acceptedSocket = serverSocket.Accept();

            var receivedValue = string.Empty;
            while (true)
            {
               var receivedBytes = new byte[MaxInfoBlock];
               int numBytes = acceptedSocket.Receive(receivedBytes);

               Console.WriteLine("Receiving...");  // Получение
               receivedValue += Encoding.ASCII.GetString(receivedBytes, 0, numBytes);

               if (receivedValue.IndexOf("[FINAL]", StringComparison.Ordinal) > -1)
               {
                  break;
               }
            }

            Console.WriteLine("Received value: {0}", receivedValue);
            const string replyValue = "Message successfully received."; // Сообщение принято успешно
            byte[] replyMessage = Encoding.ASCII.GetBytes(replyValue);
            acceptedSocket.Send(replyMessage);
            acceptedSocket.Shutdown(SocketShutdown.Both);
            acceptedSocket.Close();
         }

         // ReSharper disable once FunctionNeverReturns
      }
   }
}
