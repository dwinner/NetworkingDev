using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using MenuPlanner.Properties;

namespace MenuPlanner.Models
{
   public class UsersContext : DbContext
   {
      public UsersContext()
         : base("DefaultConnection")
      {
      }

      public DbSet<UserProfile> UserProfiles { get; set; }
   }

   [Table("UserProfile")]
   public class UserProfile
   {
      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public int UserId { get; set; }
      public string UserName { get; set; }
   }

   public class RegisterExternalLoginModel
   {
      [Required]
      [Display(ResourceType = typeof(Resources), Name = "UserName")]
      public string UserName { get; set; }

      public string ExternalLoginData { get; set; }
   }

   public class LocalPasswordModel
   {
      [Required]
      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "CurrentPassword")]
      public string OldPassword { get; set; }

      [Required]
      [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValueMustBeGreaterThanTwoSymbols", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "NewPassword")]
      public string NewPassword { get; set; }

      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "ConfirmPassword")]
      [Compare("NewPassword", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NewAndConfirmPassIsNotTheSame")]
      public string ConfirmPassword { get; set; }
   }

   public class LoginModel
   {
      [Required]
      [Display(ResourceType = typeof(Resources), Name = "UserName")]
      public string UserName { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "Password")]
      public string Password { get; set; }

      [Display(ResourceType = typeof(Resources), Name = "RememberMe")]
      public bool RememberMe { get; set; }
   }

   public class RegisterModel
   {
      [Required]
      [Display(ResourceType = typeof(Resources), Name = "UserName")]
      public string UserName { get; set; }

      [Required]
      [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValueMustBeGreaterThanTwoSymbols", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "Password")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(ResourceType = typeof(Resources), Name = "ConfirmPassword")]
      [Compare("Password", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NewAndConfirmPassIsNotTheSame")]
      public string ConfirmPassword { get; set; }
   }

   public class ExternalLogin
   {
      public string Provider { get; set; }
      public string ProviderDisplayName { get; set; }
      public string ProviderUserId { get; set; }
   }
}
