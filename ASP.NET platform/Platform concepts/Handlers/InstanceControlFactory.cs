using System.Web;

namespace Handlers
{
   /// <summary>
   /// Специальная фабрика обработчиков
   /// </summary>
   public class InstanceControlFactory : IHttpHandlerFactory
   {
      private int _factoryCounter;

      public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
      {
         return new InstanceControlHandler(++_factoryCounter);
      }

      public void ReleaseHandler(IHttpHandler handler)
      {
         // Ничего не делать - обработчики не используются повторно
      }

      private class InstanceControlHandler : IHttpHandler
      {
         private readonly int _handlerCounter;

         public InstanceControlHandler(int handlerCounter)
         {
            _handlerCounter = handlerCounter;
         }

         public void ProcessRequest(HttpContext context)
         {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The counter value is {0}", _handlerCounter));
         }

         public bool IsReusable { get { return false; } }
      }
   }
}