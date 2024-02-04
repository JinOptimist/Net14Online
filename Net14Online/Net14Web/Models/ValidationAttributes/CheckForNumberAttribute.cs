using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes;

public class CheckForNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not null && value is not int)
        {
            throw new ArgumentException("Введите число!");
        }
        
        var someIntValue = (int)value;
        
        return someIntValue > 0;
    }
}