using Net14Web.DbStuff.Models.Enums;
using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.Dnd
{
    public class AddHeroViewModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [MaxLength(5, ErrorMessage = "Я не верю в такие длинные имена. Не больше 5 символов")]
        
        [ForbidenStrings("Иван", "Лера", ErrorMessage = "Во славу Императора")]
        public string Name { get; set; }
        
        [MaxLength(10)]
        [ForbidenStrings("1.jpg")]
        public string? AvatarUrl { get; set; }

        [HpCoinSummMaxValue]
        public int? Coin { get; set; }

        public Race Race { get; set; }

        public int? Hp { get; set; }

        public string? UserName { get; set; }
    }
}
