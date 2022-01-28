using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Emso.WebUi.Models;
using Emso.WebUi.Properties;

namespace Emso.WebUi.ViewModels.Metadata
{
   public class JobVacancyMetadata
   {
      [Key]      
      [HiddenInput]
      public int Id { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "PositionTitle")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TitleRequired",
         AllowEmptyStrings = false)]
      [DataType(DataType.Text, ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "TitleMustBeText")]
      public string Title { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "LocationCity")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CityRequired",
         AllowEmptyStrings = false)]
      [DataType(DataType.Text, ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "CityMustBeText")]
      public string City { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "SalaryLevel")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "SalaryLevelRequired")]
      public decimal SalaryLevel { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "WorkExperience")]
      public Experience WorkExperience { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "EmploymentType")]
      public EmploymentType EmploymentType { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "IsActive")]
      public bool IsActive { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "Responsibilities")]
      public IList<string> Responsibilities { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "Other")]
      public IList<string> Misc { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "Requirements")]
      public IList<string> Requirements { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "OptionalRequirements")]
      public IList<string> RestRequirements { get; set; }
      
      [Display(ResourceType = typeof(Resources), Name = "WorkingConditions")]
      public IList<string> WorkingConditions { get; set; }
   }
}