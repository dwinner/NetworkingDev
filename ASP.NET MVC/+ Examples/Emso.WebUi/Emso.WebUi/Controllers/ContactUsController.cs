using System.Threading.Tasks;
using System.Web.Mvc;
using Emso.Configuration;
using Emso.WebUi.Infrastructure.ControllerExtensibility;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Properties;
using Emso.WebUi.Utils;
using Emso.WebUi.ViewModels;

namespace Emso.WebUi.Controllers
{
   public class ContactUsController : CookieRouteLocalizationController
   {
      private readonly IContactSender _contactSender;
      private readonly ICredentials _credentials;
      private readonly IRecipientCollection _recipients;
      private readonly IResumeManagerRepository _resumeManager;

      public ContactUsController(IContactSender contactSender,
         ICredentials credentials,
         IRecipientCollection recipients,
         IResumeManagerRepository resumeManager)
      {
         _contactSender = contactSender;
         _credentials = credentials;
         _recipients = recipients;
         _resumeManager = resumeManager;
      }

      [HttpGet]
      public ActionResult Create()
      {
         return View(new ContactPersonViewModel());
      }

      [HttpPost]
      [ActionName("Create")]
      public async Task<ActionResult> CreateAsync(ContactPersonViewModel person)
      {
         if (!ModelState.IsValid)
         {
            return View(person);
         }
         
         var sessionId = HttpContext.GetSessionId();
         var resumeAttachments =
            await _resumeManager.GetFilesAsync(sessionId, MimeTypeId.Pdf).ConfigureAwait(false);
         var codeExamplesAttachments =
            await _resumeManager.GetFilesAsync(sessionId, MimeTypeId.Zip).ConfigureAwait(false);

         // TOREFACTOR: Отправка почты - довольно долгая операция, которая может привести к таймауту (с дальнейшей отменой операции):
         // стоит предусмотреть очередь на отправку, вместо фактического ожидания
         var contactUsResult =
            await
               _contactSender.ContactUsAsync(
                  person, resumeAttachments, codeExamplesAttachments, _credentials, _recipients).ConfigureAwait(false);

         if (contactUsResult)
         {            
            /*var deletedCount = */await _resumeManager.DeleteAsync(sessionId).ConfigureAwait(false);            
            TempData[TempDataContants.NotificationKey] = Resources.ContactUsController_SuccessfullySent;
            return RedirectToAction("Index", "Home");
         }

         ModelState.AddModelError(string.Empty, Resources.ContactUsController_ErrorSendingEmail);

         return View(person);
      }
   }
}