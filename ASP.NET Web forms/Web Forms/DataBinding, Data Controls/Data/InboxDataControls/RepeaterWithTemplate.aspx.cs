// Создание шаблона программным образом

using Data.Models;
using Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.InboxDataControls
{
   public partial class RepeaterWithTemplate : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         DemoRep.ItemTemplate = new RowTemplate();
      }

      public IEnumerable<Product> GetProducts()
      {
         return new Repository().Products;
      }
   }

   public class RowTemplate : ITemplate
   {
      public void InstantiateIn(Control container)
      {
         var literal = new Literal();
         container.Controls.Add(literal);
         container.DataBinding += (sender, args) =>
         {
            var dataItemContainer = container as IDataItemContainer;
            if (dataItemContainer == null)
               return;

            var product = dataItemContainer.DataItem as Product;
            if (product != null)
            {
               literal.Text = string.Format("<tr {0}><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                  dataItemContainer.DataItemIndex % 2 == 1 ? "class=\"alternate\"" : string.Empty, product.Name,
                  product.Category, product.Price.ToString("F2"));
            }
         };
      }
   }
}