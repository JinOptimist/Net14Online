using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.BookingWeb
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "The name shouldnt be longer than 10 symbols!")]
        [ForbiddenNameAttribute(ErrorMessage = "Field Name can only contain letters")]
        public string Name { get; set; }   
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The password is too short!")]
        public string Password { get; set; }

        public string? Owner { get; set; }
    }
}
