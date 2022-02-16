using System.Collections.Concurrent;
using System.Web;

namespace Handlers
{
   /// <summary>
   ///    Фабрика обработчиков для повторного использования
   /// </summary>
   public class RecyclingFactory : IHttpHandlerFactory
   {
      private const int HandlerLimit = 100;
      private readonly BlockingCollection<RecylingHandler> _pool = new BlockingCollection<RecylingHandler>();
      private int _handlerCount;
      private int _totalRequests;

      public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
      {
         _totalRequests++;
         RecylingHandler handler;
         if (!_pool.TryTake(out handler))
         {
            if (_handlerCount < HandlerLimit)
            {
               _handlerCount++;
               handler = new RecylingHandler(this, _handlerCount);
               _pool.Add(handler);
            }
            else
            {
               handler = _pool.Take();
            }
         }

         handler.RequestCount++;
         return handler;
      }

      public void ReleaseHandler(IHttpHandler handler)
      {
         if (handler.IsReusable)
         {
            _pool.Add((RecylingHandler)handler);
         }
      }

      private class RecylingHandler : IHttpHandler
      {
         private readonly RecyclingFactory _factory;
         private readonly int _handlerId;

         public RecylingHandler(RecyclingFactory factory, int handlerId)
         {
            _handlerId = handlerId;
            _factory = factory;
         }

         public int RequestCount { get; set; }

         public void ProcessRequest(HttpContext context)
         {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("Total requests: {0}, HandlerId: {1}, Handler requests: {2}",
               _factory._totalRequests, // Всего запросов
               _handlerId, // Идентификатор обработчика
               RequestCount)); // Запросов обработчика
         }

         public bool IsReusable
         {
            get { return RequestCount < 4; }
         }
      }
   }
}