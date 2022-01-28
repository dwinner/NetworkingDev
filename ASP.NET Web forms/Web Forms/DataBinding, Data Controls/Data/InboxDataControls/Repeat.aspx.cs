using Data.Models;
using Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Data.InboxDataControls
{
   public partial class Repeat : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<Product> GetProducts()
      {
         return new Repository().Products;
      }
   }
}