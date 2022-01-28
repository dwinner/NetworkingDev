using System;
using System.Net;
using System.Net.Sockets;

namespace SimpleMulticastSender
{
   public class MulticastSender
   {
      public void Send(string mcastGroup, string port, string ttlValue, string rep)
      {
         try
         {
            Console.WriteLine("MCAST Send on Group: {0} Port: {1} TTL: {2}", mcastGroup, port, ttlValue);
            var ipAddr = IPAddress.Parse(mcastGroup);

            var s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ipAddr));
            s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, int.Parse(ttlValue));

            var b = new byte[10];
            for (var x = 0; x < b.Length; x++)
            {
               b[x] = (byte) (x + 65);
            }

            var ipep = new IPEndPoint(IPAddress.Parse(mcastGroup), int.Parse(port));

            Console.WriteLine("Connecting...");

            s.Connect(ipep);

            for (var x = 0; x < int.Parse(rep); x++)
            {
               Console.WriteLine("Sending ABCDEFGHIJ...");
               s.Send(b, b.Length, SocketFlags.None);
            }

            Console.WriteLine("Closing Connection...");
            s.Close();
         }
         catch (Exception e)
         {
            Console.Error.WriteLine(e.Message);
         }
      }
   }
}