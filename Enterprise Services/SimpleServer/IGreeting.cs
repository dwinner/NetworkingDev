using System.Runtime.InteropServices;

namespace SimpleServer
{
   [ComVisible(true)]
   public interface IGreeting
   {
      string Welcome(string aName);
   }
}