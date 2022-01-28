using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleMulticastReceiver
{
   public class MulticastReceiver
   {
      public void Receive(string mcastGroup, string port)
      {
         var s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
         var ipep = new IPEndPoint(IPAddress.Any, int.Parse(port));
         s.Bind(ipep);
         var ip = IPAddress.Parse(mcastGroup);
         s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
            new MulticastOption(ip, IPAddress.Any));

         while (true)
         {
            var b = new byte[10];
            Console.WriteLine("Waiting for data..");
            s.Receive(b);
            var str = Encoding.ASCII.GetString(b, 0, b.Length);
            Console.WriteLine("RX: " + str.Trim());
         }

         //s.Close();
      }
   }
}