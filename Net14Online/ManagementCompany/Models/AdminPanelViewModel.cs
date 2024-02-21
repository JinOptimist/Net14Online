using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class AdminPanelViewModel : BaseViewModel
    {
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
        [RegularExpression(@"^\+[0-9]+$", ErrorMessage = "Поле должно начинаться с + и должно содержать только фиырф от 0-9")]
        public string? CompanyPhoneNumber { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string ProjectName { get; set; }

        [MaxLength(10, ErrorMessage = "Максимальная длина 10 символов")]
        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Допустимы заглавные буквы, цифры от 0-9, знак _")]
        public string ProjectShortName { get; set; }

        public string? ProjectAdress { get; set; }


        public string ProjectLinkCompany { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(1, ErrorMessage = "Минимальная длина 1 символ")]
        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Поле должно содержать только буквы")]
        public string ExecutorFirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(1, ErrorMessage = "Минимальная длина 1 символ")]
        [MaxLength(30, ErrorMessage = "Максимальная длина 30 символов")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Поле должно содержать только буквы")]
        public string ExecutorLastName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        public string ExecutorNickName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Поле должно содержать @ и .")]
        public string ExecutorEmail { get; set; }

        [MinLength(10)]
        [RegularExpression(@"^\+[0-9]+$", ErrorMessage = "Поле должно начинаться с + и должно содержать только фиырф от 0-9")]
        public string? ExecutorPhoneNumber { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string ExecutorMemberRole { get; set; }

        public string? ExecutorMemberPermission { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string ExecutorPassword { get; set; }

        public DateTime? ExecutorExpireDate { get; set; }

        public List<StatusViewModel> Statuses { get; set; }

        public List<PermissionViewModel> Permissions { get; set; }

        public List<CompanyViewModel> Companies { get; set; }

        public List<ProjectViewModel> Projects { get; set; }

        public List<ExecutorViewModel> Executors { get; set; }
    }
}
