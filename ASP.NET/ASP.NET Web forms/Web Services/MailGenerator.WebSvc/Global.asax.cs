using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace MailGenerator.WebSvc
{
   public class Global : HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         using (
            var mailGenConnection =
               new SqlConnection(
                  ConfigurationManager.ConnectionStrings["MailGeneratorConnectionString"].ConnectionString))
         {
            mailGenConnection.Open();
            var mailGetDataSet = new DataSet();

            using (var contactAdapter = new SqlDataAdapter("SELECT * FROM Contact", mailGenConnection))
            {
               contactAdapter.Fill(mailGetDataSet, "Contacts");
            }

            Application["contacts"] = mailGetDataSet;
         }
      }
   }
}