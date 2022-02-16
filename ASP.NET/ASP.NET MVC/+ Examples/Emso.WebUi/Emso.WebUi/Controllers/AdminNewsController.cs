using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AutoMapper;
using Emso.WebUi.Infrastructure;
using Emso.WebUi.Infrastructure.Auth;
using Emso.WebUi.Infrastructure.ControllerExtensibility;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Properties;
using Emso.WebUi.Utils;
using Emso.WebUi.ViewModels;
using EmsoHr.Entities;

namespace Emso.WebUi.Controllers
{
   [Authorize(Roles = IdentityDbInit.AdminRoleName)]
   public class AdminNewsController : CookieRouteLocalizationController
   {
      private readonly IRssFeedSource _feedSource;
      private static readonly int _PageSize = int.Parse(WebConfigurationManager.AppSettings["PageSize"]);

      public AdminNewsController(IRssFeedSource feedSource)
      {
         _feedSource = feedSource;
      }

      // GET: AdminNews
      [ActionName("Index")]
      public async Task<ActionResult> IndexAsync(int page = 1)
      {
         var newsFeeds = await _feedSource.GetAllNewsAsync().ConfigureAwait(false);
         var feedVms = newsFeeds.Select(Mapper.Map<RssFeedViewModel>).ToList();  // PERFORMANCE-NOTE: На каждой странице приходится запрашивать все данные по новостям
         var navigationVm = new NavigationViewModel<RssFeedViewModel>
         {
            PageElements = feedVms.OrderByDescending(model => model.NewsDate).Skip((page - 1)*_PageSize).Take(_PageSize),
            Navigator = new PagingNavigator
            {
               CurrentPageNumber = page,
               ItemsPerPageCount = _PageSize,
               TotalItemsCount = feedVms.Count
            }
         };

         return View(navigationVm);
      }

      // GET: AdminNews/Details/5
      [ActionName("Details")]
      public async Task<ActionResult> DetailsAsync(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var feed = await _feedSource.GetNewsAsync(id.Value).ConfigureAwait(false);
         var rssFeedVm = Mapper.Map<RssFeedViewModel>(feed);
         if (rssFeedVm == null)
         {
            return HttpNotFound();
         }

         return PartialView(rssFeedVm);
      }

      // GET: AdminNews/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: AdminNews/Create        
      [HttpPost]
      [ValidateAntiForgeryToken]
      [ActionName("Create")]
      public async Task<ActionResult> CreateAsync(
         [Bind(Include = "Title,Details,RelatedLink")] RssFeedViewModel rssFeedVm, HttpPostedFileBase imageFile)
      {
         if (!ModelState.IsValid)
         {
            return View(rssFeedVm);
         }

         var newsFeed = Mapper.Map<NewsFeed>(rssFeedVm);
         newsFeed.NewsDate = DateTime.Now;
         if (imageFile != null && imageFile.FileName != null)
         {
            var imageMimeType = imageFile.ContentType;
            if (
               !ImageProcessorUtils.ImageMimeTypes.Any(
                  mimeType => imageMimeType.Equals(mimeType, StringComparison.OrdinalIgnoreCase)))
            {
               ModelState.AddModelError(string.Empty, string.Format(Resources.NotAnImage, imageFile.FileName));
               return RedirectToAction("Create");
            }

            var imageStream = imageFile.InputStream;
            var imageBytes = await imageStream.ToByteArrayAsync().ConfigureAwait(false);
            newsFeed.ImageData = imageBytes;
            newsFeed.ImageMimeType = imageMimeType;
         }

         await _feedSource.AddNewsAsync(newsFeed).ConfigureAwait(false);
         TempData[TempDataContants.NotificationKey] = string.Format(Resources.NewsSuccessfullyCreated, newsFeed.Title);
         return RedirectToAction("Index");
      }

      // GET: AdminNews/Edit/5
      [ActionName("Edit")]
      public async Task<ActionResult> EditAsync(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var feedToEdit = await _feedSource.GetNewsAsync(id.Value).ConfigureAwait(false);
         if (feedToEdit == null)
         {
            return HttpNotFound();
         }

         var rssFeedVm = Mapper.Map<RssFeedViewModel>(feedToEdit);
         return View(rssFeedVm);
      }

      // POST: AdminNews/Edit/5      
      [HttpPost]
      [ValidateAntiForgeryToken]
      [ActionName("Edit")]
      public async Task<ActionResult> EditAsync(
         [Bind(Include = "FeedId,Title,Details,RelatedLink")] RssFeedViewModel rssFeedVm, HttpPostedFileBase imageFile)
      {
         if (!ModelState.IsValid)
         {
            return View(rssFeedVm);
         }

         var existingNews = await _feedSource.GetNewsAsync(rssFeedVm.FeedId).ConfigureAwait(false);
         var newsFeed = Mapper.Map<NewsFeed>(rssFeedVm);
         newsFeed.NewsDate = existingNews.NewsDate;
         if (imageFile != null && imageFile.FileName != null)
         {
            var imageStream = imageFile.InputStream;
            var imageBytes = await imageStream.ToByteArrayAsync().ConfigureAwait(false);
            newsFeed.ImageData = imageBytes;
            newsFeed.ImageMimeType = imageFile.ContentType;
         }
         else
         {
            newsFeed.ImageData = existingNews.ImageData;
            newsFeed.ImageMimeType = existingNews.ImageMimeType;
         }

         var isSuccessfullyUpdated = await _feedSource.UpdateNewsAsync(newsFeed).ConfigureAwait(false);
         if (!isSuccessfullyUpdated)
         {
            ModelState.AddModelError(string.Empty, Resources.FailedToUpdate);
            return View(rssFeedVm);
         }

         TempData[TempDataContants.NotificationKey] = string.Format(Resources.NewsSuccessfullyUpdated, newsFeed.Title);
         return RedirectToAction("Index");
      }

      // GET: AdminNews/Delete/5
      [ActionName("Delete")]
      public async Task<ActionResult> DeleteAsync(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var feed = await _feedSource.GetNewsAsync(id.Value).ConfigureAwait(false);
         if (feed == null)
         {
            return HttpNotFound();
         }

         var rssFeedVm = Mapper.Map<RssFeedViewModel>(feed);
         return PartialView(rssFeedVm);
      }

      // POST: AdminNews/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      [ActionName("Delete")]
      public async Task<ActionResult> DeleteConfirmedAsync(int id)
      {
         var feed = await _feedSource.GetNewsAsync(id).ConfigureAwait(false);
         var rssFeedVm = Mapper.Map<RssFeedViewModel>(feed);
         var isSuccessfullyDeleted = await _feedSource.RemoveNewsAsync(feed).ConfigureAwait(false);
         if (!isSuccessfullyDeleted)
         {
            ModelState.AddModelError(string.Empty, Resources.FailedToDeleteNews);
            return View(rssFeedVm);
         }

         TempData[TempDataContants.NotificationKey] = string.Format(Resources.NewsSuccessfullyDeleted, rssFeedVm.Title);
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _feedSource.Dispose();
         }

         base.Dispose(disposing);
      }

      [ActionName("GetNewsImage")]
      public async Task<FileContentResult> GetNewsImageAsync(int pictureId)
      {
         var newsFeed = await _feedSource.GetNewsAsync(pictureId).ConfigureAwait(false);
         var imageData = newsFeed.ImageData;
         return imageData != null ? File(imageData, newsFeed.ImageMimeType) : null;
      }
   }
}