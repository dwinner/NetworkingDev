using System.Runtime.InteropServices;

namespace NorthwindComponent
{
   [ComVisible(true)]
   [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
   public interface IOrderControl
   {
      void NewOrder(Order order);
   }
}