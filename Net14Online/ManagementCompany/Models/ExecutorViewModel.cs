using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class ExecutorViewModel : BaseViewModel
    {
        public int Id { get; set; }

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
        public string ExecutorMemberStatus { get; set; }

        public string? ExecutorMemberPermission { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string ExecutorPassword { get; set; }

        public string Company { get; set; }

        public DateTime? ExecutorExpireDate { get; set; }

        //public List<Project>? Projects { get; set; }

        //public List<UserTask>? ExecutorTasks { get; set; }

        internal List<SelectListItem> Companies { get; set; }

        internal List<SelectListItem> Projects { get; set; }

        internal List<SelectListItem> Permissions { get; set; }

        internal List<SelectListItem> Statuses { get; set; }
    }
}
