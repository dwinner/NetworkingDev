using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace Events
{
   /// <summary>
   ///    Модуль локализации
   /// </summary>
   public class LocaleModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += HandleEvent;
      }

      public void Dispose()
      {
      }

      private static void HandleEvent(object sender, EventArgs e)
      {
         var httpApp = sender as HttpApplication;
         if (httpApp != null)
         {
            string[] langs = httpApp.Request.UserLanguages;
            if (langs != null && langs.Length > 0 && langs[0] != null)
            {
               try
               {
                  Thread.CurrentThread.CurrentCulture = new CultureInfo(langs[0]);
               }
               catch (CultureNotFoundException)
               {
               }
            }
         }
      }
   }
}