using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class LoginViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Все буквы должны быть в нижнем регистре. Поле должно содержать @ и .")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string Password { get; set; }
    }
}
