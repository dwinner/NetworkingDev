using System;
using System.Web.Mvc.Async;
using System.Web.Routing;

namespace ControllerExtensibility.Controllers
{
   public class AsyncControllerImpl : IAsyncController
   {
      public void Execute(RequestContext requestContext)
      {
         throw new NotImplementedException();
      }

      public IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
      {
         throw new NotImplementedException();
      }

      public void EndExecute(IAsyncResult asyncResult)
      {
         throw new NotImplementedException();
      }
   }
}