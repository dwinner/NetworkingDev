using System.Data;

namespace MailGenerator.WebSvc
{
   public interface IContactAccess
   {
      DataSet GetContacts();

      bool AddContact(string name, string mail, string text, string link);
   }
}