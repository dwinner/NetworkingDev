using System.Web.Mvc;

namespace CustomViewEngine.Infrastructure
{
   /// <summary>
   ///    Специальная реализация механизма визуализации
   /// </summary>
   public class DebugDataViewEngine : IViewEngine
   {
      public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
      {
         return new ViewEngineResult(new[] { "No view (Debug Data View Engine)" });
      }

      public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName,
         bool useCache)
      {
         return viewName == "DebugData"
            ? new ViewEngineResult(new DebugDataView(), this)
            : new ViewEngineResult(new[] { "No view (Debug Data View Engine)" });
      }

      public void ReleaseView(ControllerContext controllerContext, IView view)
      {
         // Ничего не делать
      }
   }
}