using Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Data.InboxDataControls
{
   public partial class Drop : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            selection.InnerText = DemoDdl.SelectedValue;
         }
      }

      public IEnumerable<string> GetProducts()
      {
         return new Repository().Products.Select(product => product.Name);
      }
   }
}