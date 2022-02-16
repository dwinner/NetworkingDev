using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Emso.WebUi.Infrastructure.ControllerExtensibility;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.ViewModels;

namespace Emso.WebUi.Controllers
{
   public class VacancyController : CookieRouteLocalizationController
   {
      private readonly IJobVacancyRepository _jobVacancyRepo;

      public VacancyController(IJobVacancyRepository jobVacancyRepo)
      {
         _jobVacancyRepo = jobVacancyRepo;
      }

      [ActionName("Index")]
      public async Task<ActionResult> IndexAsync()
      {
         var vacancies = await _jobVacancyRepo.GetVacanciesAsync().ConfigureAwait(false);
         var vacancyVms =
            (from vacancy in vacancies where vacancy.IsActive select Mapper.Map<JobVacancyViewModel>(vacancy)).ToList();
         return PartialView(vacancyVms);
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