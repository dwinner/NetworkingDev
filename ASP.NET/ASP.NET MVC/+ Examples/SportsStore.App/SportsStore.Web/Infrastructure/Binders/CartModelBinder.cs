/**
 * Специальный связыватель модели
 */

using System.Web.Mvc;
using SportsStore.Domain.Entites;

namespace SportsStore.Web.Infrastructure.Binders
{
   public class CartModelBinder : IModelBinder
   {
      private const string SessionCartKey = "Cart";

      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
         // Получить объект Cart из сеанса
         Cart cart = null;
         if (controllerContext.HttpContext.Session != null)
         {
            cart = controllerContext.HttpContext.Session[SessionCartKey] as Cart;
         }

         // Создать экземпляр Cart, если он не обнаружен в данных сеанса
         if (cart == null)
         {
            cart = new Cart();
            if (controllerContext.HttpContext.Session != null)
            {
               controllerContext.HttpContext.Session[SessionCartKey] = cart;
            }
         }

         // Возвратить объект Cart
         return cart;
      }
   }
}