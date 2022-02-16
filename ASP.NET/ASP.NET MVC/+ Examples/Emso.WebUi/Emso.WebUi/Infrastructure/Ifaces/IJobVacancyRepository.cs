using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmsoHr.Entities;

namespace Emso.WebUi.Infrastructure.Ifaces
{
   /// <summary>
   ///    Repository bridge class for job vacancies
   /// </summary>
   public interface IJobVacancyRepository : IDisposable
   {
      /// <summary>
      ///    Getting all vacancies
      /// </summary>
      /// <returns>All vacancies</returns>
      Task<IEnumerable<JobVacancy>> GetVacanciesAsync();

      /// <summary>
      ///    Getting vacancy
      /// </summary>
      /// <param name="aVacancyId">Vacancy id to get</param>
      /// <returns>Vacancy</returns>
      Task<JobVacancy> GetVacancyAsync(int aVacancyId);

      /// <summary>
      ///    Adding vacancy
      /// </summary>
      /// <param name="aJobVacancy">Job vacancy to add</param>
      /// <returns>Added vacancy</returns>
      Task<JobVacancy> AddVacancyAsync(JobVacancy aJobVacancy);

      /// <summary>
      ///    Removing vacancy
      /// </summary>
      /// <param name="aVacancyId">Vacancy id to delete</param>
      /// <returns>Removed vacancy</returns>
      Task<bool> RemoveVacancyAsync(int aVacancyId);

      /// <summary>
      ///    Update vacancy
      /// </summary>      
      /// <param name="aJobVacancy">Updated vacancy</param>
      /// <returns>true, if vacancy has been updated successfully, false otherwise</returns>
      Task<bool> UpdateVacancyAsync(JobVacancy aJobVacancy);
   }
}