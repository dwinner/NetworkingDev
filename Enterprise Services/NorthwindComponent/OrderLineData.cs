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
   public class OrderLineData : ServicedComponent, IOrderLineUpdate
   {
      private string _connectionString;

      public void Insert(int orderId, OrderLine orderLine)
      {
         SqlConnection northConnection = null;

         try
         {
            northConnection = new SqlConnection(_connectionString);
            SqlCommand insertCmd = northConnection.CreateCommand();
            insertCmd.CommandText =
               "INSERT INTO [Order Details] (OrderId, ProductId, UnitPrice, Quantity) VALUES (@OrderId, @ProductId, @UnitPrice, @Quantity)";
            insertCmd.Parameters.AddWithValue("@OrderId", orderId);
            insertCmd.Parameters.AddWithValue("@ProductId", orderLine.ProductId);
            insertCmd.Parameters.AddWithValue("@UnitPrice", orderLine.UnitPrice);
            insertCmd.Parameters.AddWithValue("@Quantity", orderLine.Quantity);
            northConnection.Open();
            insertCmd.ExecuteNonQuery();
         }
         catch (Exception)
         {
            ContextUtil.SetAbort();
            throw;
         }
         finally
         {
            if (northConnection != null && northConnection.State != ConnectionState.Closed)
               northConnection.Close();
         }

         ContextUtil.SetComplete();
      }

      protected override void Construct(string s)
      {
         _connectionString = s;
      }
   }
}