using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore.Pages.Admin
{
   public partial class Orders : System.Web.UI.Page
   {
      private readonly SportsStoreRepository _repository = new SportsStoreRepository();

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            return;
         }

         int dispatchId;
         if (!int.TryParse(Request.Form["dispatch"], out dispatchId))
         {
            return;
         }

         Order userOrder = _repository.Orders.FirstOrDefault(order => order.OrderId == dispatchId);
         if (userOrder == null)
         {
            return;
         }

         userOrder.Dispatched = true;
         _repository.Save(userOrder);
      }

      // ReSharper disable once ParameterHidesMember
      public IEnumerable<Order> GetOrders([Control] bool showDispathed)
      {
         return showDispathed ? _repository.Orders : _repository.Orders.Where(order => !order.Dispatched);
      }
   }
}