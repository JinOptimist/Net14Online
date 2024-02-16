using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.GameShop
{
    public class CreateGameModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [MaxLength(30)]
        [ForbidenNameAttribure]
        public string Name { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public string? Genre { get; set; }
    }
}
