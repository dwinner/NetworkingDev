using System.Runtime.InteropServices;

namespace NorthwindComponent
{
   [ComVisible(true)]
   public interface IOrderLineUpdate
   {
      void Insert(int orderId, OrderLine orderLine);
   }
}