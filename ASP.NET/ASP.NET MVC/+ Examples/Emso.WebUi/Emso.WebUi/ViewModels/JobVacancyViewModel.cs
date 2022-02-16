using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Emso.WebUi.Models;
using Emso.WebUi.ViewModels.Metadata;

namespace Emso.WebUi.ViewModels
{
   /// <summary>
   ///    A view model class for JobVacancy
   /// </summary>
   [MetadataType(typeof (JobVacancyMetadata))]
   public sealed class JobVacancyViewModel
   {
      /// <summary>
      ///    Job Id
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      ///    Job title
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      ///    Location city
      /// </summary>
      public string City { get; set; }

      /// <summary>
      ///    Salary level
      /// </summary>
      public decimal SalaryLevel { get; set; }

      /// <summary>
      ///    Work experience
      /// </summary>
      public Experience WorkExperience { get; set; }

      /// <summary>
      ///    Employment type
      /// </summary>
      public EmploymentType EmploymentType { get; set; }

      /// <summary>
      ///    Job vacancy is active
      /// </summary>
      public bool IsActive { get; set; }

      /// <summary>
      ///    Main responsibilities
      /// </summary>
      public IList<string> Responsibilities { get; set; }

      /// <summary>
      ///    Other notes
      /// </summary>
      public IList<string> Misc { get; set; }

      /// <summary>
      ///    Main requirements
      /// </summary>
      public IList<string> Requirements { get; set; }

      /// <summary>
      ///    Rest requirements
      /// </summary>
      public IList<string> RestRequirements { get; set; }

      /// <summary>
      ///    Working conditions
      /// </summary>
      public IList<string> WorkingConditions { get; set; }
   }
}