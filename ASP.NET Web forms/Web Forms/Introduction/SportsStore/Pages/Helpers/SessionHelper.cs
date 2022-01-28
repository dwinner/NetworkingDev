using System;
using System.Web.SessionState;
using SportsStore.Models;

namespace SportsStore.Pages.Helpers
{
   /// <summary>
   /// Класс-прослойка для сеанса
   /// </summary>
   public static class SessionHelper
   {
      public static void Set(HttpSessionState session, SessionKey sessionKey, object value)
      {
         session[Enum.GetName(typeof(SessionKey), sessionKey)] = value;
      }

      public static T Get<T>(HttpSessionState session, SessionKey key)
      {
         object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
         return dataValue is T ? (T)dataValue : default(T);
      }

      public static Cart GetCart(HttpSessionState session)
      {
         var myCart = Get<Cart>(session, SessionKey.Cart);
         if (myCart != null)
         {
            return myCart;
         }

         myCart = new Cart();
         Set(session, SessionKey.Cart, myCart);

         return myCart;
      }
   }
}