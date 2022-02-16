using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Emso.WebUi.Infrastructure.Auth;
using Emso.WebUi.Infrastructure.ControllerExtensibility;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Utils;
using Emso.WebUi.ViewModels;
using EmsoHr.Entities;

namespace Emso.WebUi.Controllers
{
   [Authorize(Roles = IdentityDbInit.AdminRoleName)]
   public class CrudJobVacancyController : CookieRouteLocalizationController
   {
      private const string DetailsActionName = "Details";
      private const string CreateActionName = "Create";
      private const string EditActionName = "Edit";
      private const string DeleteActionName = "Delete";
      private readonly IJobVacancyRepository _jobVacancyRepo;

      public CrudJobVacancyController(IJobVacancyRepository jobVacancyRepo)
      {
         _jobVacancyRepo = jobVacancyRepo;
      }

      [ActionName("Index")]
      public async Task<ActionResult> IndexAsync()
      {
         var jobVacancies = await _jobVacancyRepo.GetVacanciesAsync().ConfigureAwait(false);
         var jobVacancyVms = jobVacancies.Select(Mapper.Map<JobVacancyViewModel>).ToList();
         return View(jobVacancyVms);
      }

      [ActionName(DetailsActionName)]
      public async Task<ActionResult> DetailsAsync(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var jobVacancy = await _jobVacancyRepo.GetVacancyAsync(id.Value).ConfigureAwait(false);
         var jobVacancyVm = Mapper.Map<JobVacancyViewModel>(jobVacancy);

         if (jobVacancyVm == null)
         {
            return HttpNotFound();
         }

         return PartialView(jobVacancyVm);
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ActionName(CreateActionName)]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> CreateAsync(JobVacancyViewModel jobVacancyVm,
         IList<string> responsibilities,
         IList<string> requirements,
         IList<string> workConditions,
         IList<string> restRequirements,
         IList<string> miscsellaneaos)
      {
         if (ModelState.IsValid)
         {
            jobVacancyVm.Validate(responsibilities, requirements, workConditions, restRequirements, miscsellaneaos);
            var jobVacancy = Mapper.Map<JobVacancy>(jobVacancyVm);
            await _jobVacancyRepo.AddVacancyAsync(jobVacancy).ConfigureAwait(false);
            return RedirectToAction("Index");
         }

         return View(jobVacancyVm);
      }

      [ActionName(EditActionName)]
      public async Task<ActionResult> EditAsync(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var jobVacancy = await _jobVacancyRepo.GetVacancyAsync(id.Value).ConfigureAwait(false);
         var jobVacancyVm = Mapper.Map<JobVacancyViewModel>(jobVacancy);
         if (jobVacancyVm == null)
         {
            return HttpNotFound();
         }

         return View(jobVacancyVm);
      }

      [HttpPost]
      [ActionName(EditActionName)]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> EditAsync(JobVacancyViewModel jobVacancyVm,
         IList<string> responsibilities,
         IList<string> requirements,
         IList<string> workConditions,
         IList<string> restRequirements,
         IList<string> miscsellaneaos)
      {
         if (ModelState.IsValid)
         {
            jobVacancyVm.Validate(responsibilities, requirements, workConditions, restRequirements, miscsellaneaos);
            var jobVacancy = Mapper.Map<JobVacancy>(jobVacancyVm);
            await _jobVacancyRepo.UpdateVacancyAsync(jobVacancy).ConfigureAwait(false);
            return RedirectToAction("Index");
         }

         return View(jobVacancyVm);
      }

      [ActionName(DeleteActionName)]
      public async Task<ActionResult> DeleteAsync(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var jobVacancy = await _jobVacancyRepo.GetVacancyAsync(id.Value).ConfigureAwait(false);
         var jobVacancyVm = Mapper.Map<JobVacancyViewModel>(jobVacancy);
         if (jobVacancyVm == null)
         {
            return HttpNotFound();
         }

         return PartialView(jobVacancyVm);
      }

      [HttpPost]
      [ActionName(DeleteActionName)]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> DeleteConfirmedAsync(int id)
      {
         await _jobVacancyRepo.RemoveVacancyAsync(id).ConfigureAwait(false);
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _jobVacancyRepo.Dispose();
         }

         base.Dispose(disposing);
      }
   }
}