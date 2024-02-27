using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.Bonds
{
    public class AddBondsViewModel
    {
        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; }
        public int Id { get; set; }

        [CheckingForPositiveNumbers(ErrorMessage = "Вот ты фокусник")]
        public int Price { get; set; }

    }
}
