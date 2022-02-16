using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Charts
{
   public partial class ObjectAdapterBinding : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         using (var popObjectDataSource = new ObjectDataSource("PopObjectDataSource", "GetData"))
         {
            ObjectAdapterChart.DataSource = popObjectDataSource;
            ObjectAdapterChart.Series[0].XValueMember = "Name";
            ObjectAdapterChart.Series[0].YValueMembers = "Popularity";
         }
      }
   }

   public class PopObjectDataSource
   {
      public DataItem[] GetData()
      {
         return new[]
         {
            new DataItem {Name = "Cheesecake", Popularity = 30},
            new DataItem {Name = "Ice Cream", Popularity = 30},
            new DataItem {Name = "Fudge", Popularity = 20},
            new DataItem {Name = "Milkshake", Popularity = 20}
         };
      }
   }

   public class DataItem
   {
      public string Name { get; set; }
      public double Popularity { get; set; }
   }
}