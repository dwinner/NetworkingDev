using System.ComponentModel.DataAnnotations;
using I18n.Web.Properties;

namespace I18n.Web.Models
{
   public class Person
   {
      [Display(ResourceType = typeof(Resources), Name = "FirstName")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FirstNameRequired")]
      [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FirstNameMaxLength")]
      public string FirstName { get; set; }

      [Display(ResourceType = typeof(Resources), Name = "LastName")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LastNameRequired")]
      [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LastNameMaxLen")]
      public string LastName { get; set; }

      [Display(ResourceType = typeof(Resources), Name = "Age")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRequired")]
      [Range(0, 130, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeBetween")]
      public int Age { get; set; }

      [Display(ResourceType = typeof(Resources), Name = "Email")]
      [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailRequired")]
      [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources),
         ErrorMessageResourceName = "EmailNotValid")]
      public string Email { get; set; }

      [Display(ResourceType = typeof(Resources), Name = "Biography")]
      public string Biography { get; set; }
   }
}