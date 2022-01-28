namespace SimpleMulticastSender
{
   internal static class Program
   {
      private static void Main(string[] args)
      {
         var sender = new MulticastSender();
         sender.Send("224.5.6.7", "5000", "1", "2");
      }
   }
}