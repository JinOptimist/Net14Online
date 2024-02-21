using ManagementCompany.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class RegistrationViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Поле должно содержать @ и .")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [CheckPasswordRegView]
        public string Password { get; set; }
    }
}
