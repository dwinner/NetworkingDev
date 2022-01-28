/**
 * Простейшая реализация TCP/IP сервера
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TcpIpListener = System.Net.Sockets.TcpListener;

namespace TcpListener
{
   internal static class Program
   {
      private const string DefaultIpAAddress = "127.0.0.1";
      private const int DefaultListeningPort = 1330;

      private static void Main()
      {
         var localhost = IPAddress.Parse(DefaultIpAAddress);
         var listener = new TcpIpListener(localhost, DefaultListeningPort);
         listener.Start();

         while (true)
         {
            Console.WriteLine("Waiting for connection");
            var client = listener.AcceptTcpClient(); // Объект AcceptTcpClient ждет соединения с клиентом            
            var thread = new Thread(HandleClientThread);
               // Запустить новый поток выполнения для обработки этого соединения,
            thread.Start(client); // чтобы иметь возможность вернуться к ожиданию очередного соединения
         }
      }

      private static void HandleClientThread(object obj)
      {
         var client = obj as TcpClient;

         var done = false;
         while (!done)
         {
            var received = ReadMessage(client);
            Console.WriteLine("Received: {0}", received);
            done = received.Equals("bye");
            SendResponse(client, done ? "BYE" : "OK");
         }
         if (client != null)
            client.Close();
         Console.WriteLine("Connection closed");
      }

      private static string ReadMessage(TcpClient client)
      {
         var buffer = new byte[0x100];
         var totalRead = 0;
         // Считывать байты, пока поток данных не проинформирует,
         // что они закончились
         do
         {
            var read = client.GetStream().Read(buffer, totalRead, buffer.Length - totalRead);
            totalRead += read;
         } while (client.GetStream().DataAvailable);

         return Encoding.Unicode.GetString(buffer, 0, totalRead);
      }

      private static void SendResponse(TcpClient client, string message)
      {
         // На другом конце мы должны использовать тот же формат
         var bytes = Encoding.Unicode.GetBytes(message);
         client.GetStream().Write(bytes, 0, bytes.Length);
      }
   }
}