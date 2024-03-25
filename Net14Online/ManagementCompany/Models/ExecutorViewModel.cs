using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models
{
    public class ExecutorViewModel : BaseViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")]
        //[MinLength(1, ErrorMessage = "Минимальная длина 1 символ")]
        //[MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        //[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Поле должно содержать только буквы")]
        public string? FirstName { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")]
        //[MinLength(1, ErrorMessage = "Минимальная длина 1 символ")]
        //[MaxLength(30, ErrorMessage = "Максимальная длина 30 символов")]
        //[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Поле должно содержать только буквы")]
        public string? LastName { get; set; }

       //[Required(ErrorMessage = "Обязательное поле")]
        //[MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        public string? NickName { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")]
        //[RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Поле должно содержать @ и .")]
        public string? Email { get; set; }

        //[MinLength(10)]
        //[RegularExpression(@"^\+[0-9]+$", ErrorMessage = "Поле должно начинаться с + и должно содержать только фиырф от 0-9")]
        public string? PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")]
        public string? MemberStatus { get; set; }

        public string? MemberPermission { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")]
        public string? Password { get; set; }

        public string? Company { get; set; }

        public DateTime? ExpireDate { get; set; }

        //public List<Project>? Projects { get; set; }

        //public List<UserTask>? ExecutorTasks { get; set; }

        internal List<SelectListItem>? Companies { get; set; }

        internal List<SelectListItem>? Projects { get; set; }

        internal List<SelectListItem>? Permissions { get; set; }

        internal List<SelectListItem>? Statuses { get; set; }
    }
}
