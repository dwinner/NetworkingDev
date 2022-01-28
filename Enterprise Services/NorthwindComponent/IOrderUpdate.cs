using System.Runtime.InteropServices;

namespace NorthwindComponent
{
   [ComVisible(true)]
   public interface IOrderUpdate
   {
      void Insert(Order order);
   }
}