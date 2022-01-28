using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace NorthwindComponent
{
   [Transaction(TransactionOption.Required)]
   [EventTrackingEnabled(true)]
   [ConstructionEnabled(Enabled = true,
      Default = @"Data Source=VINEVCEV-PC\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True")]
   [ComVisible(true)]
   public class OrderData : ServicedComponent, IOrderUpdate
   {
      private string _connectionString;

      [AutoComplete]
      public void Insert(Order order)
      {
         SqlConnection northConnection = null;

         try
         {
            northConnection = new SqlConnection(_connectionString);
            SqlCommand insertCmd = northConnection.CreateCommand();
            insertCmd.CommandText =
               "INSERT INTO Orders (CustomerId, OrderDate, ShipAddress, ShipCity, ShipCountry) VALUES (@CustomerId, @OrderDate, @ShipAddress, @ShipCity, @ShipCountry)";
            insertCmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            insertCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            insertCmd.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
            insertCmd.Parameters.AddWithValue("@ShipCity", order.ShipCity);
            insertCmd.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);

            northConnection.Open();
            insertCmd.ExecuteNonQuery();

            insertCmd.CommandText = "SELECT @@IDENTITY AS 'Identity'";
            object identity = insertCmd.ExecuteScalar();
            order.SetOrderId(Convert.ToInt32(identity));

            using (var updateOrderLine = new OrderLineData())
            {
               foreach (OrderLine orderLine in order.OrderLines)
               {
                  updateOrderLine.Insert(order.OrderId, orderLine);
               }
            }
         }
         finally
         {
            if (northConnection != null && northConnection.State != ConnectionState.Closed)
               northConnection.Close();
         }
      }

      protected override void Construct(string s)
      {
         _connectionString = s;
      }
   }
}