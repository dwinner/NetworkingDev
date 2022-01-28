using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace NorthwindComponent
{
   [Transaction(TransactionOption.Supported)]
   [EventTrackingEnabled(true)]
   [ComVisible(true)]   
   public class OrderControl : ServicedComponent, IOrderControl
   {
      [AutoComplete]
      public void NewOrder(Order order)
      {
         using (var data = new OrderData())
         {
            data.Insert(order);
         }
      }
   }
}