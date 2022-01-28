using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Emso.WebUi.Infrastructure.Ifaces;
using EmsoHr.Entities;

namespace Emso.WebUi.Infrastructure.Impl
{
   /// <summary>
   ///    Sql job vacancy repository implementation
   /// </summary>
   public sealed class SqlServerEfJobVacancyRepository : IJobVacancyRepository
   {
      private readonly EmsoHrEntities _hrEntities = new EmsoHrEntities();

      #region IJobVacancyRepository

      public void Dispose()
      {
         _hrEntities.Dispose();
      }

      /// <summary>
      ///    Getting all vacancies
      /// </summary>
      /// <returns>All vacancies</returns>
      public async Task<IEnumerable<JobVacancy>> GetVacanciesAsync()
      {
         var jobVacancies = _hrEntities.JobVacancies;
         return await Task.Run<IEnumerable<JobVacancy>>(() => jobVacancies).ConfigureAwait(false);
      }

      /// <summary>
      ///    Getting vacancy
      /// </summary>
      /// <param name="aVacancyId">Vacancy id to get</param>
      /// <returns>Vacancy</returns>
      public async Task<JobVacancy> GetVacancyAsync(int aVacancyId)
      {
         return await _hrEntities.JobVacancies.FindAsync(aVacancyId).ConfigureAwait(false);
      }

      /// <summary>
      ///    Adding vacancy
      /// </summary>
      /// <param name="aJobVacancy">Job vacancy to add</param>
      /// <returns>Added vacancy</returns>
      public async Task<JobVacancy> AddVacancyAsync(JobVacancy aJobVacancy)
      {
         var jobVacancy = _hrEntities.JobVacancies.Add(aJobVacancy);
         await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         return jobVacancy;
      }

      /// <summary>
      ///    Removing vacancy
      /// </summary>
      /// <param name="aVacancyId">Vacancy id to delete</param>
      /// <returns>Removed vacancy</returns>
      public async Task<bool> RemoveVacancyAsync(int aVacancyId)
      {
         var vacancy = await GetVacancyAsync(aVacancyId).ConfigureAwait(false);
         if (vacancy == null)
         {
            return false;
         }

         _hrEntities.JobVacancies.Remove(vacancy);
         int affectedCount = await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         return affectedCount > 0;
      }

      /// <summary>
      ///    Update vacancy
      /// </summary>
      /// <param name="aJobVacancy">Updated vacancy</param>
      /// <returns>true, if vacancy has been updated successfully, false otherwise</returns>
      public async Task<bool> UpdateVacancyAsync(JobVacancy aJobVacancy)
      {
         var affectedCount = 0;
         var sourceJob = _hrEntities.JobVacancies.FirstOrDefault(vacancy => vacancy.JobId == aJobVacancy.JobId);
         if (sourceJob != null)
         {
            UpdateResponsibilities(aJobVacancy, sourceJob);
            UpdateRequirements(aJobVacancy, sourceJob);
            UpdateWorkingConditions(aJobVacancy, sourceJob);
            UpdateMisc(aJobVacancy, sourceJob);
            UpdateRestRequirements(aJobVacancy, sourceJob);
         }

         affectedCount += await _hrEntities.SaveChangesAsync().ConfigureAwait(false);
         return affectedCount > 0;
      }

      #endregion

      #region Private methods

      private static void UpdateRestRequirements(JobVacancy modifiedVacancy, JobVacancy sourceVacancy)
      {
         var miscComparer = new RestRequirementEqualityComparer();
         var modified = modifiedVacancy.JobVacancyRestRequirements;
         var source = sourceVacancy.JobVacancyRestRequirements;

         var added = modified.Except(source, miscComparer).ToArray();
         var deleted = source.Except(modified, miscComparer).ToArray();

         if (deleted.Length > 0)
         {
            foreach (var misc in deleted)
            {
               sourceVacancy.JobVacancyRestRequirements.Remove(misc);
            }
         }

         if (added.Length > 0)
         {
            foreach (var misc in added)
            {
               sourceVacancy.JobVacancyRestRequirements.Add(misc);
            }
         }
      }

      private static void UpdateMisc(JobVacancy modifiedVacancy, JobVacancy sourceVacancy)
      {
         var miscComparer = new MiscEqualityComparer();
         var modified = modifiedVacancy.JobVacancyMiscs;
         var source = sourceVacancy.JobVacancyMiscs;

         var added = modified.Except(source, miscComparer).ToArray();
         var deleted = source.Except(modified, miscComparer).ToArray();

         if (deleted.Length > 0)
         {
            foreach (var misc in deleted)
            {
               sourceVacancy.JobVacancyMiscs.Remove(misc);
            }
         }

         if (added.Length > 0)
         {
            foreach (var misc in added)
            {
               sourceVacancy.JobVacancyMiscs.Add(misc);
            }
         }
      }

      private static void UpdateWorkingConditions(JobVacancy modifiedVacancy, JobVacancy sourceVacancy)
      {
         var workingConditionsComparer = new WorkingConditionsEqualityComparer();
         var modified = modifiedVacancy.JobVacancyWorkingConditions;
         var source = sourceVacancy.JobVacancyWorkingConditions;

         var added = modified.Except(source, workingConditionsComparer).ToArray();
         var deleted = source.Except(modified, workingConditionsComparer).ToArray();

         if (deleted.Length > 0)
         {
            foreach (var condition in deleted)
            {
               sourceVacancy.JobVacancyWorkingConditions.Remove(condition);
            }
         }

         if (added.Length > 0)
         {
            foreach (var condition in added)
            {
               sourceVacancy.JobVacancyWorkingConditions.Add(condition);
            }
         }
      }

      private static void UpdateResponsibilities(JobVacancy modifiedVacancy, JobVacancy sourceVacancy)
      {
         var responsibilityComparer = new ResponsibilityEqualityComparer();
         var modified = modifiedVacancy.JobVacancyMainResponsibilities;
         var source = sourceVacancy.JobVacancyMainResponsibilities;

         var added = modified.Except(source, responsibilityComparer).ToArray();
         var deleted = source.Except(modified, responsibilityComparer).ToArray();

         if (deleted.Length > 0)
         {
            foreach (var responsibility in deleted)
            {
               sourceVacancy.JobVacancyMainResponsibilities.Remove(responsibility);
            }
         }

         if (added.Length > 0)
         {
            foreach (var responsibility in added)
            {
               sourceVacancy.JobVacancyMainResponsibilities.Add(responsibility);
            }
         }
      }

      private static void UpdateRequirements(JobVacancy modifiedVacancy, JobVacancy sourceVacancy)
      {
         var requirementComparer = new RequirementEqualityComparer();
         var modified = modifiedVacancy.JobVacancyRequirements;
         var source = sourceVacancy.JobVacancyRequirements;

         var added = modified.Except(source, requirementComparer).ToArray();
         var deleted = source.Except(modified, requirementComparer).ToArray();

         if (deleted.Length > 0)
         {
            foreach (var requirement in deleted)
            {
               sourceVacancy.JobVacancyRequirements.Remove(requirement);
            }
         }

         if (added.Length > 0)
         {
            foreach (var requirement in added)
            {
               sourceVacancy.JobVacancyRequirements.Add(requirement);
            }
         }
      }

      #endregion

      #region Private types

      private sealed class RestRequirementEqualityComparer : IEqualityComparer<JobVacancyRestRequirement>
      {
         public bool Equals(JobVacancyRestRequirement x, JobVacancyRestRequirement y)
         {
            return x.MiscRequirement.Equals(y.MiscRequirement, StringComparison.CurrentCultureIgnoreCase);
         }

         public int GetHashCode(JobVacancyRestRequirement obj)
         {
            return obj.MiscRequirement.ToLower().GetHashCode();
         }
      }

      private sealed class MiscEqualityComparer : IEqualityComparer<JobVacancyMisc>
      {
         public bool Equals(JobVacancyMisc x, JobVacancyMisc y)
         {
            return string.Compare(x.MiscItem, y.MiscItem, StringComparison.InvariantCultureIgnoreCase) == 0;
         }

         public int GetHashCode(JobVacancyMisc obj)
         {
            return obj.MiscItem.ToLower(CultureInfo.CurrentCulture).GetHashCode();
         }
      }

      private sealed class WorkingConditionsEqualityComparer : IEqualityComparer<JobVacancyWorkingCondition>
      {
         public bool Equals(JobVacancyWorkingCondition x, JobVacancyWorkingCondition y)
         {
            return string.Compare(
                      x.ConditionItem, y.ConditionItem, StringComparison.CurrentCultureIgnoreCase) == 0;
         }

         public int GetHashCode(JobVacancyWorkingCondition obj)
         {
            return obj.ConditionItem.ToLower(CultureInfo.CurrentCulture).GetHashCode();
         }
      }

      private sealed class RequirementEqualityComparer : IEqualityComparer<JobVacancyRequirement>
      {
         public bool Equals(JobVacancyRequirement x, JobVacancyRequirement y)
         {
            return string.Compare(
                      x.RequirementItem, y.RequirementItem, StringComparison.CurrentCultureIgnoreCase) == 0;
         }

         public int GetHashCode(JobVacancyRequirement obj)
         {
            return obj.RequirementItem.ToLower(CultureInfo.CurrentCulture).GetHashCode();
         }
      }

      private sealed class ResponsibilityEqualityComparer : IEqualityComparer<JobVacancyMainResponsibility>
      {
         public bool Equals(JobVacancyMainResponsibility x, JobVacancyMainResponsibility y)
         {
            return string.Compare(
                      x.ResponsibilityItem, y.ResponsibilityItem, StringComparison.CurrentCultureIgnoreCase) == 0;
         }

         public int GetHashCode(JobVacancyMainResponsibility obj)
         {
            return obj.ResponsibilityItem.ToLower(CultureInfo.CurrentCulture).GetHashCode();
         }
      }

      #endregion
   }
}