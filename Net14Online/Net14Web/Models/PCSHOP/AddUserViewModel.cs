using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.PcShop
{
    public class AddUserViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Данное поле обязательно для ввода")]
        [UserNamePcShop(ErrorMessage = "В данном поле не могут содержаться цифры")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Данное поле обязательно для ввода")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Данное поле обязательно для ввода")]
        [StringLength(255, ErrorMessage = "Минимальная длина пароля 5 символов", MinimumLength = 5)]
        [PasswordPcShop(ErrorMessage = "Пароль должен содержать: одну маленькую букву, одну большую букву, цифры и символы")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Данное поле обязательно для ввода")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string Email { get; set; }
    }
}
