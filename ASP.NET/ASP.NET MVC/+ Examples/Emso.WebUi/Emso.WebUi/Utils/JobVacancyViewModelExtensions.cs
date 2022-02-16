using System.Collections.Generic;
using System.Linq;
using Emso.WebUi.ViewModels;
using EmsoHr.Entities;

namespace Emso.WebUi.Utils
{
   public static class JobVacancyViewModelExtensions
   {
      public static ICollection<JobVacancyMainResponsibility> ToResponsibilities(this JobVacancyViewModel jobVacancyVm)
      {
         var responsibilities = new List<JobVacancyMainResponsibility>(jobVacancyVm.Responsibilities.Count);
         responsibilities.AddRange(jobVacancyVm.Responsibilities.Select(resp => new JobVacancyMainResponsibility
         {
            JobId = jobVacancyVm.Id,
            ResponsibilityItem = resp
         }));

         return responsibilities;
      }

      public static ICollection<JobVacancyMisc> ToMisc(this JobVacancyViewModel jobVacancyVm)
      {
         var vacancyMiscs = new List<JobVacancyMisc>(jobVacancyVm.Misc.Count);
         vacancyMiscs.AddRange(jobVacancyVm.Misc.Select(resp => new JobVacancyMisc
         {
            JobId = jobVacancyVm.Id,
            MiscItem = resp
         }));

         return vacancyMiscs;
      }

      public static ICollection<JobVacancyRequirement> ToRequirements(this JobVacancyViewModel jobVacancyVm)
      {
         var requirements = new List<JobVacancyRequirement>(jobVacancyVm.Requirements.Count);
         requirements.AddRange(jobVacancyVm.Requirements.Select(req => new JobVacancyRequirement
         {
            JobId = jobVacancyVm.Id,
            RequirementItem = req
         }));

         return requirements;
      }

      public static ICollection<JobVacancyRestRequirement> ToRestRequirements(this JobVacancyViewModel jobVacancyVm)
      {
         var restRequirements = new List<JobVacancyRestRequirement>(jobVacancyVm.RestRequirements.Count);
         restRequirements.AddRange(jobVacancyVm.RestRequirements.Select(restReq => new JobVacancyRestRequirement
         {
            JobId = jobVacancyVm.Id,
            MiscRequirement = restReq
         }));

         return restRequirements;
      }

      public static ICollection<JobVacancyWorkingCondition> ToWorkingConditions(this JobVacancyViewModel jobVacancyVm)
      {
         var conditions = new List<JobVacancyWorkingCondition>(jobVacancyVm.WorkingConditions.Count);
         conditions.AddRange(jobVacancyVm.WorkingConditions.Select(workCond => new JobVacancyWorkingCondition
         {
            JobId = jobVacancyVm.Id,
            ConditionItem = workCond
         }));

         return conditions;
      }

      public static void Validate(this JobVacancyViewModel jobVacancyVm,
         IEnumerable<string> responsibilities,
         IEnumerable<string> requirements,
         IEnumerable<string> workConditions,
         IEnumerable<string> restRequirements,
         IEnumerable<string> miscsellaneaos)
      {
         if (responsibilities != null)
            jobVacancyVm.Responsibilities = responsibilities.Where(resp => !string.IsNullOrWhiteSpace(resp)).ToList();

         jobVacancyVm.Requirements = requirements != null
            ? requirements.Where(req => !string.IsNullOrWhiteSpace(req)).ToList()
            : new List<string>();

         if (workConditions != null)
            jobVacancyVm.WorkingConditions = workConditions.Where(wc => !string.IsNullOrWhiteSpace(wc)).ToList();

         jobVacancyVm.RestRequirements = restRequirements != null
            ? restRequirements.Where(restRq => !string.IsNullOrWhiteSpace(restRq)).ToList()
            : new List<string>();

         jobVacancyVm.Misc = miscsellaneaos != null
            ? miscsellaneaos.Where(misc => !string.IsNullOrWhiteSpace(misc)).ToList()
            : new List<string>();
      }
   }
}