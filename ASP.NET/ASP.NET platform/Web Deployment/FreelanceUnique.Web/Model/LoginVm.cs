using System;
using System.ComponentModel.DataAnnotations;

namespace FreelanceUnique.Web.Model
{
    [Serializable]
    public class LoginVm
    {
        [Required(ErrorMessage = "Нужно заполнить поле Логина")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Нужно заполнить поле Пароля")]
        public string Password { get; set; }
    }
}