using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class ProjectViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string ProjectName { get; set; }

        [MaxLength(10, ErrorMessage = "Максимальная длина 10 символов")]
        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Допустимы заглавные буквы, цифры от 0-9, знак _")]
        public string ProjectShortName { get; set; }

        public string? ProjectAdress { get; set; }

        public string? ProjectStatus { get; set; }

        public string ProjectLinkCompany { get; set; }

        internal List<SelectListItem> Companies { get; set; }

        internal List<SelectListItem> Projects { get; set; }

        internal List<SelectListItem> Permissions { get; set; }

        internal List<SelectListItem> Statuses { get; set; }
    }
}
