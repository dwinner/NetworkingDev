using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace FileUploadViaWebApi.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public JsonResult Upload()
      {
         foreach (var file in Request.Files.Cast<string>())
         {
            var postedFile = Request.Files[file];
            if (postedFile != null)
            {
               // Получаем имя файла
               var fileName = Path.GetFileName(postedFile.FileName);
               // Сохраняем файл
               postedFile.SaveAs(Server.MapPath(string.Format("~/Uploaded/{0}", fileName)));
            }
         }

         return Json("File uploaded");
      }
   }
}