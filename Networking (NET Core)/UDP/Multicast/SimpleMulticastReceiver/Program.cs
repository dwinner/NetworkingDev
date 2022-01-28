namespace SimpleMulticastReceiver
{
   internal static class Program
   {
      private static void Main(string[] args)
      {
         var receiver = new MulticastReceiver();
         receiver.Receive("224.5.6.7", "5000");
      }
   }
}