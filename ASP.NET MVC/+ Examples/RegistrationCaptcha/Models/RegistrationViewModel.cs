using System.ComponentModel.DataAnnotations;
using RegistrationCaptcha.Properties;

namespace RegistrationCaptcha.Models
{
   public class RegistrationViewModel
   {
      [Required]
      [Display(ResourceType = typeof(Resources), Name = "Name")]
      public string Name { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "Password")]
      public string Password { get; set; }

      [Required]
      [Display(ResourceType = typeof(Resources), Name = "ConfirmPassword")]
      public string ConfirmPassword { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "Captcha")]
      public string Captcha { get; set; }
   }
}