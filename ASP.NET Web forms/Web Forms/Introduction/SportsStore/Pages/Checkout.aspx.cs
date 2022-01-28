using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
   public partial class Checkout : Page
   {
      private readonly SportsStoreRepository _storeRepository = new SportsStoreRepository();

      protected void Page_Load(object sender, EventArgs e)
      {
         checkoutForm.Visible = true;
         checkoutMessage.Visible = false;

         if (!IsPostBack)
         {
            return;
         }

         var userOrder = new Order();
         if (!TryUpdateModel(userOrder, new FormValueProvider(ModelBindingExecutionContext)))
         {
            return;
         }

         userOrder.OrderLines = new List<OrderLine>();
         Cart userCart = SessionHelper.GetCart(Session);
         foreach (var cartLine in userCart.Lines.ToArray())
         {
            userOrder.OrderLines.Add(new OrderLine
            {
               Order = userOrder,
               Product = cartLine.Product,
               Quantity = cartLine.Quantity
            });

            _storeRepository.Save(userOrder);
            userCart.Clear();

            checkoutForm.Visible = false;
            checkoutMessage.Visible = true;
         }
      }
   }
}