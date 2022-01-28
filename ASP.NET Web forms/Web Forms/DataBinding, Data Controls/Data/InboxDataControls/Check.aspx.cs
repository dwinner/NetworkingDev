using Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.InboxDataControls
{
   public partial class Check : Page
   {
      private readonly Repository _repository = new Repository();

      protected void Page_Init(object src, EventArgs args)
      {
         DemoCbl.SelectedIndexChanged += (sender, eventArgs) =>
         {
            selection.InnerText = string.Join(", ",
               (from item in DemoCbl.Items.Cast<ListItem>()
                where item.Selected
                select item.Value).ToArray());
         };
      }

      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<string> GetProducts()
      {
         return _repository.Products.Select(product => product.Name);
      }
   }
}