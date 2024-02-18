using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.GameShop
{
    public class AddGameViewModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [MaxLength(30)]
        [ForbidenNameAttribure]
        public string? Name { get; set; }

        public string? PosterUrl { get; set; }

        public string? Genre { get; set; }
    }
}
