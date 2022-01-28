using System;
using System.Web.Http;
using GroupBrush.BusinessLogic.Canvases;
using GroupBrush.Entity;

namespace GroupBrush.Web.Public.Controllers
{
   public class CanvasController : ApiController
   {
      private readonly ICanvasService _canvasService;

      public CanvasController(ICanvasService canvasService)
      {
         _canvasService = canvasService;
      }

      [Route("api/canvas")]
      [HttpPost]
      public Guid? CreateCanvas(CanvasDescription canvasDescription)
      {
         Guid? canvasId = null;
         if (canvasDescription != null)
         {
            canvasId = _canvasService.CreateCanvas(canvasDescription);
         }

         return canvasId;
      }

      [Route("api/canvas")]
      [HttpPut]
      public Guid? LookUpCanvas(CanvasName canvasName)
      {
         Guid? canvasId = null;
         if (canvasName != null)
         {
            canvasId = _canvasService.LookUpCanvas(canvasName.Name);
         }

         return canvasId;
      }
   }
}