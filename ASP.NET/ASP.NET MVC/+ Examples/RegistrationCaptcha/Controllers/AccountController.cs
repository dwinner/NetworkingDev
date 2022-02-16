using System.Drawing.Imaging;
using System.Web.Mvc;
using RegistrationCaptcha.Models;
using RegistrationCaptcha.Properties;
using RegistrationCaptcha.Utils;

namespace RegistrationCaptcha.Controllers
{
   public class AccountController : Controller
   {
      public ActionResult Register()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Register(RegistrationViewModel user)
      {
         if (user.Captcha != (string)Session["code"])
         {
            ModelState.AddModelError("Captcha", Resources.NotValidCaptcha);
            return View(user);
         }

         return RedirectToAction("Success");
      }

      public ActionResult Captcha()
      {
         var randomCode = RndUtils.GenerateRandomCode();
         Session["code"] = randomCode;
         using (var randomImage = new RandomImage(Session["code"].ToString(), 300, 75))
         {
            Response.Clear();
            Response.ContentType = "image/jpeg";
            randomImage.Image.Save(Response.OutputStream, ImageFormat.Jpeg);            
         }

         return null;
      }

      public ActionResult Success()
      {
         return View();
      }
   }
}