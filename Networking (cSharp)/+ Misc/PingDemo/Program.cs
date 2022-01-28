/**
 * Пингование компьютера
 */

using System;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace PingDemo
{
   class Program
   {
      static void Main()
      {
         Ping ping = new Ping();
         PingReply reply = ping.Send("yahoo.com");
         Debug.Assert(reply != null, "reply != null");
         Console.WriteLine("address: {0}", reply.Address);
         Console.WriteLine("options: don't fragment: {0}, TTL: {1}", reply.Options.DontFragment, reply.Options.Ttl);
         Console.WriteLine("rountrip: {0}ms", reply.RoundtripTime);
         Console.WriteLine("status: {0}", reply.Status);

         Console.ReadKey();
      }
   }
}
