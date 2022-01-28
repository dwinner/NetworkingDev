using System.Web;
using System.Web.SessionState;

namespace State
{
   /// <summary>
   ///    Модуль для безопасной установки состояния сеанса
   /// </summary>
   public class StateModule : IHttpModule
   {
      public void Dispose()
      {
      }

      public void Init(HttpApplication httpApp)
      {
         httpApp.PostAcquireRequestState += (sender, args) =>
         {
            HttpSessionState sessionState = httpApp.Context.Session;
            if (sessionState != null && sessionState.IsNewSession && !sessionState.IsReadOnly)
            {
               sessionState["color"] = Color.Green;
               sessionState["city"] = City.London;
            }
         };
      }
   }

   public enum City
   {
      London,
      Paris,
      Chicago
   }

   public enum Color
   {
      Red,
      Green,
      Blue
   }
}