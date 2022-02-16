using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;

namespace MailGenerator.WebSvc
{
   /// <summary>
   ///    WEB-сервис для взаимодействия с таблицей контактов
   /// </summary>
   [WebService(Namespace = "http://bloodhound.com/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   [ScriptService]
   public class MailGeneratorService : WebService, IContactAccess
   {
      [WebMethod]
      public DataSet GetContacts()
      {
         return (DataSet) Application["contacts"];
      }

      [WebMethod]
      public bool AddContact(string name, string mail, string text = null, string link = null)
      {
         bool anyAffected;

         using (
            var mailGeneratorConnection =
               new SqlConnection(
                  ConfigurationManager.ConnectionStrings["MailGeneratorConnectionString"].ConnectionString))
         using (
            var insertContactCmd =
               new SqlCommand("INSERT INTO Contact (Name, Mail, Text, Link) VALUES (@Name, @Mail, @Text, @Link)",
                  mailGeneratorConnection))
         {
            insertContactCmd.Parameters.Add("Name", SqlDbType.NVarChar, 0x80).Value = name;
            insertContactCmd.Parameters.Add("Mail", SqlDbType.VarChar, 0x80).Value = mail;
            insertContactCmd.Parameters.Add("Text", SqlDbType.VarChar, 0x400).Value = text;
            insertContactCmd.Parameters.Add("Link", SqlDbType.VarChar, 0x400).Value = link;
            mailGeneratorConnection.Open();
            var affected = insertContactCmd.ExecuteNonQuery();
            anyAffected = affected > 0;
            if (anyAffected)
            {
               var contactsAdapter = new SqlDataAdapter("SELECT * FROM Contact", mailGeneratorConnection);
               var contactDataSet = (DataSet) Application["contacts"];
               contactDataSet.Tables["Contacts"].Clear();
               contactsAdapter.Fill(contactDataSet, "Contacts");
               try
               {
                  Application.Lock();
                  Application["contacts"] = contactDataSet;
               }
               finally
               {
                  Application.UnLock();
               }
            }
         }

         return anyAffected;
      }
   }
}