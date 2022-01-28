using System.ComponentModel.DataAnnotations;

namespace FreelanceUnique.Web.Model
{
    public class RegisterVm
    {
        [Required(ErrorMessage = "Нужно заполнить поле Логина")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Нужно заполнить поле Email")]
        [EmailAddress(ErrorMessage = "Email не соответствует формату")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Нужно заполнить поле Пароля")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен быть в пределах от 6 до 20 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле для подтверждения пароля обязательно для заполнения")]
        public string ConfirmPassword { get; set; }
    }
}