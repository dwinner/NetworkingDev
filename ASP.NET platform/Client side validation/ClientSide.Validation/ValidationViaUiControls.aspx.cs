using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using System.Web.UI;
using ClientSide.Validation.Models;

namespace ClientSide.Validation
{
   public partial class ValidationViaUiControls : Page
   {
      private readonly Repository _repo = new Repository();
      private List<Product> _createdProducts;

      protected void Page_Load(object sender, EventArgs e)
      {
         _createdProducts = (List<Product>) ViewState["data"] ?? new List<Product>();
         if (IsPostBack)
         {
            var newProduct = new Product();
            TryUpdateModel(newProduct, new FormValueProvider(ModelBindingExecutionContext));
            if (ModelState.IsValid)
            {
               _repo.Add(newProduct);
               _createdProducts.Add(newProduct);
               ViewState["data"] = _createdProducts;
               DataBind();
            }
         }
      }

      public IEnumerable<Product> GetCreated()
      {
         return _createdProducts;
      }
   }
}