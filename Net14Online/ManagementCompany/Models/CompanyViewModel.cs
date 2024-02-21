using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class CompanyViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(10, ErrorMessage = "Максимальная длина 10 символов")]
        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Допустимы заглавные буквы, цифры от 0-9, знак _")]
        public string CompanyShortName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Поле должно содержать @ и .")]
        public string CompanyEmail { get; set; }

        public string? CompanyAdress { get; set; }

        [MinLength(10)]
        [RegularExpression(@"^\+[0-9]+$", ErrorMessage = "Поле должно начинаться с + и должно содержать только цифры от 0-9")]
        public string? CompanyPhoneNumber { get; set; }

        public string? CompanyStatus { get; set; }

        internal List<SelectListItem> Companies { get; set; }

        internal List<SelectListItem> Projects { get; set; }

        internal List<SelectListItem> Permissions { get; set; }

        internal List<SelectListItem> Statuses { get; set; }
    }
}
