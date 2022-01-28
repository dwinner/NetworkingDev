using System.Data;

namespace Autolot.FakeLib
{
   public class InventoryDalDisLayer
   {
      public DataTable GetAllInventory()
      {
         return new DataTable("Inventory");
      }
   }
}