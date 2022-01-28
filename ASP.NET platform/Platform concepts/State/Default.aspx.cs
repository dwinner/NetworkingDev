using System;
//using System.Web.Profile;
using System.Globalization;
using System.Web;
using System.Web.UI;

namespace State
{
   public partial class Default : Page
   {
      //private string _user;
      private int _counter;

      protected void Page_Load(object sender, EventArgs e)
      {
         #region Использование данных представления

         _counter = (int) (ViewState["counter"] ?? 0);
         ViewState["counter"] = ++_counter;

         #endregion

         #region Использование cookie-наборов

         HttpCookie incomingCookie = Request.Cookies["counter"];
         _counter = incomingCookie == null ? 0 : int.Parse(incomingCookie.Value);
         _counter++;
         Response.Cookies.Add(new HttpCookie("counter", _counter.ToString(CultureInfo.InvariantCulture)));

         #endregion

         //_user = Request.Form["RequestedUser"] ?? "Joe";
      }

      protected int GetCounter()
      {
         #region Хранение данных приложения

         //Application.Lock();
         //var result = (int)(Application["counter"] ?? 0);
         //Application["counter"] = ++result;
         //Application.UnLock();
         //return result;

         #endregion

         #region Хранение данных профиля

         //var profile = ProfileBase.Create(_user);
         //var counter = (int)profile["counter"];
         //profile["counter"] = ++counter;
         //profile.Save();
         //return counter;

         #endregion

         #region Использование данных представления

         return _counter;

         #endregion
      }

      protected int GetSessionCounter()
      {
         var counter = (int) (Session["counter"] ?? 0);
         Session["counter"] = ++counter;
         return counter;
      }
   }
}