using System.ComponentModel.DataAnnotations;
using Emso.WebUi.Properties;

namespace Emso.WebUi.Models
{
   public enum EmploymentType
   {
      [Display(ResourceType = typeof (Resources), Name = "EmploymentType_Full")]
      Full,

      [Display(ResourceType = typeof (Resources), Name = "EmploymentType_Part")]
      Part,

      [Display(ResourceType = typeof (Resources), Name = "EmploymentType_Flexible")]
      Flexible,

      [Display(ResourceType = typeof (Resources), Name = "EmploymentType_Remote")]
      Remote
   }
}