/**
 * Простейший TCP/IP клиент
 */

using System;
using System.Net.Sockets;
using System.Text;

namespace TcpClientTest
{
   class Program
   {
      private const string DefaultHostname = "127.0.0.1";
      private const int DefaultPort = 1330;

      static void Main()
      {
         TcpClient client = new TcpClient(DefaultHostname, DefaultPort);
         bool done = false;
         Console.WriteLine("Type 'bye' to end connection");
         while (!done)
         {
            Console.Write("Enter a message to send to server: ");
            string message = Console.ReadLine();

            SendMessage(client, message);

            string response = ReadResponse(client);
            Console.WriteLine("Response: {0}", response);
            done = response.Equals("BYE");
         }
      }

      private static void SendMessage(TcpClient client, string message)
      {
         // На другом конце линии необходимо использовать тот же формат
         byte[] bytes = Encoding.Unicode.GetBytes(message);
         client.GetStream().Write(bytes, 0, bytes.Length);
      }

      private static string ReadResponse(TcpClient client)
      {
         byte[] buffer = new byte[256];
         int totalRead = 0;
         do   // Читать байты, пока ни одного не останется
         {
            int read = client.GetStream().Read(buffer, totalRead,
                buffer.Length - totalRead);
            totalRead += read;
         }
         while (client.GetStream().DataAvailable);

         return Encoding.Unicode.GetString(buffer, 0, totalRead);
      }
   }
}
