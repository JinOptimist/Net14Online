using System.ComponentModel.DataAnnotations;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.Models.ValidationAttributes;

namespace Net14Web.Models.RealEstate;

public class AddUserViewModel
{
    [Required(ErrorMessage = "Имя обязательно!")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Возраст обязательно!")]
    [CheckForNumber(ErrorMessage = "Введите число больше 0!")]
    public int Age { get; set; }
   
    public string? KindOfActivity { get; set; }
}