using System.ComponentModel.DataAnnotations;
using Net14Web.Models.ValidationAttributes;

namespace Net14Web.Models.RealEstate;

public class AddUserViewModel
{
    [Required(ErrorMessage = "Имя обязательно!")]
    public string Name { get; set; }
    
    [CheckForNumber(ErrorMessage = "Введите число больше 0!")]
    public int Age { get; set; }
    
    [CheckForString(ErrorMessage = "Введите строку!Попробуйте еще раз!")]
    public string KindOfActivity { get; set; }
    
    public string? Id { get; set; }
}