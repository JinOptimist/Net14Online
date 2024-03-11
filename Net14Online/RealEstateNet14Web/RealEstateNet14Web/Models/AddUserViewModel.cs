using System.ComponentModel.DataAnnotations;
using RealEstateNet14Web.Models.ValidationAttributes;

namespace RealEstateNet14Web.Models;

public class AddUserViewModel
{
    [Required(ErrorMessage = "Имя обязательно!")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Возраст обязательно!")]
    [CheckForNumber(ErrorMessage = "Введите число больше 0!")]
    public int Age { get; set; }
   
    public string? KindOfActivity { get; set; }
}