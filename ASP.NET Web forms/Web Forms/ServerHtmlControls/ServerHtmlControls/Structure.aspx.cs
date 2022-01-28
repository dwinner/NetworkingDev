using System;
using System.Web.UI;

namespace ServerHtmlControls
{
   public partial class Structure : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Header.Description = "A simple example";
         Header.Title = "Structure fragment";
         Header.Keywords = "ASP.NET, HTML, example, Apress";
      }
   }
}