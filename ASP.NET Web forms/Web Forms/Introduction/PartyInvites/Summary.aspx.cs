using System;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace PartyInvites
{
   public partial class Summary : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      protected string GetNoShowHtml()
      {
         var html = new StringBuilder();
         var noData =
            ResponseRepository.Instance.GetAllResponses()
               .Where(response => response.WillAttend.HasValue && !response.WillAttend.Value);
         foreach (var guestResponse in noData)
         {
            html.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
               guestResponse.Name,
               guestResponse.Email,
               guestResponse.Phone));
         }

         return html.ToString();
      }
   }
}