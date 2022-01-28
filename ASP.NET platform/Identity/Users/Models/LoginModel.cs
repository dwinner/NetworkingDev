using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
   public class LoginModel
   {
      [Required]
      public string Name { get; set; }

      [Required]
      public string Password { get; set; }
   }
}