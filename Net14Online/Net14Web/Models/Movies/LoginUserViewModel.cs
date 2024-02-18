using Microsoft.AspNetCore.Mvc;
using Net14Web.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.Movies
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Введите логин!")]
        [Remote(action: nameof(MoviesController.VerifyLoginAuthorization), controller: "Movies", ErrorMessage = "Логин не существует")]
        [MaxLength(16, ErrorMessage = "Максимальная длина логина 16 символов!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль!")]
        public string Password { get; set; }
    }
}
