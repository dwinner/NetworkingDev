using System;
using System.Linq;
using System.Web.UI;
using Charts.Entities;

namespace Charts
{
   public partial class LinqBinding : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         using (var northwndEntities = new NorthwndEntities())
         {
            var data =
               northwndEntities.Products.Where(product => !product.Discontinued).Select(product => product).Take(5);
            LinqChart.Series[0].Points.DataBind(data, "ProductName", "UnitPrice", "");
            LinqChart.Series[1].Points.DataBind(data, "ProductName", "UnitsInStock", "");
         }
      }
   }
}