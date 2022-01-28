using System;
using System.Web;

namespace Caching
{
   /// <summary>
   /// Модуль для подсчета кол-ва запросов
   /// </summary>
   public class RequestEventMapModule : IHttpModule
   {
      public event EventHandler BeginRequest;

      protected virtual void OnBeginRequest()
      {
         EventHandler handler = BeginRequest;
         if (handler != null)
            handler(this, EventArgs.Empty);
      }

      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += (sender, args) => OnBeginRequest();
      }

      public void Dispose()
      {         
      }
   }
}