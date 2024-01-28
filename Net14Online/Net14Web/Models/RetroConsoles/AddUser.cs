using System.ComponentModel.DataAnnotations;
using Net14Web.Models.ValidationAttributes;
using Net14Web.Models.RetroConsoles;

public class AddUser
{
    [Required(ErrorMessage = "Имя обязательно")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен")]
    public string Password { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Количество консолей должно быть больше 0")]
    public int NumOfConsoles { get; set; }

    public string Discription { get; set; }

    [Required(ErrorMessage = "Год выпуска обязателен")]
    [ValidYearRange(ErrorMessage = "Год должен быть в диапазоне 1960-текущий год")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Название консоли обязательно")]
    public string ConsoleName { get; set; }
    public string PicUrl { get; set; }
}
