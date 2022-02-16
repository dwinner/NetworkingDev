/**
 * Создание специальной зависимости кэша
 */

using System;
using System.Web;
using System.Web.Caching;

namespace Caching
{
   public class RequestCountDependency : CacheDependency
   {
      private readonly int _requestLimit;
      private int _requestCount;

      public RequestCountDependency(int limit)
      {
         _requestLimit = limit;
         _requestCount = 0;
         ConfigureEventHandler(true);
         FinishInit();
      }

      private void ConfigureEventHandler(bool attach)
      {
         HttpContext current = HttpContext.Current;
         if (current == null)
            return;

         var module = current.ApplicationInstance.Modules["RequestEventMap"] as RequestEventMapModule;
         if (module == null)
            return;

         if (attach)
            module.BeginRequest += HandleEvent;
         else
            module.BeginRequest -= HandleEvent;
      }

      private void HandleEvent(object sender, EventArgs e)
      {
         if (++_requestCount > _requestLimit)
            NotifyDependencyChanged(this, EventArgs.Empty);
      }

      protected override void DependencyDispose()
      {
         ConfigureEventHandler(false);
         base.DependencyDispose();
      }
   }
}