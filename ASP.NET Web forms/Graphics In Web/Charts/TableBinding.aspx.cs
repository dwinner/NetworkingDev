using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Charts
{
   public partial class TableBinding : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         RegisterAsyncTask(new PageAsyncTask(async () =>
         {
            using (
               var northSqlConnection =
                  new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            using (
               var productSqlCmd =
                  new SqlCommand("SELECT TOP 5 ProductName, UnitsInStock FROM Products WHERE Discontinued = 0",
                     northSqlConnection))
            {
               await northSqlConnection.OpenAsync();
               var productsDataReader = await productSqlCmd.ExecuteReaderAsync();
               TableChart.Series[0].Points.DataBindXY(
                  productsDataReader, "ProductName",
                  productsDataReader, "UnitsInStock");
            }
         }));         
      }
   }
}