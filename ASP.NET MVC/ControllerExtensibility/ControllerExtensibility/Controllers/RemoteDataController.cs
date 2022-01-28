using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
   /// <summary>
   ///    Действия, освобождающие простаивающие потоки пула
   /// </summary>
   public class RemoteDataController : Controller
   {
      public async Task<ActionResult> Data()
      {
         var data = await Task.Factory.StartNew(() => RemoteService.GetRemoteData());
         return View((object)data);
      }

      public async Task<ActionResult> ConsumeAsyncMethod()
      {
         var data = await RemoteService.GetRemoteDataAsync();
         return View("Data", (object)data);
      }
   }

   public static class RemoteService
   {
      public static string GetRemoteData()
      {
         Thread.Sleep(2000);
         return "Hello from the other side of the world";
      }

      public static async Task<string> GetRemoteDataAsync()
      {
         return await Task<string>.Factory.StartNew(() =>
         {
            Thread.Sleep(2000);
            return "Hello from the other side of the world";
         });
      }
   }
}