using Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.InboxDataControls
{
   public partial class List : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            var selected = (from item in DemoListbox.Items.Cast<ListItem>()
                            where item.Selected
                            select item.Value).ToArray();
            selection.InnerText = string.Join(", ", selected);
         }
      }

      public IEnumerable<string> GetProducts()
      {
         return new Repository().Products.Select(product => product.Name);
      }
   }
}