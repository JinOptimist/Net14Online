using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes;

public class CheckForString :ValidationAttribute
{
    private string[] _forbiddenStocks;

    public CheckForString(params string[] forbiddenStocks) 
    { 
        _forbiddenStocks = forbiddenStocks;
    }
    
    public override bool IsValid(object? value)
    {
        if (value is not null && value is not string)
        {
            throw new ArgumentException("Это должна быьб строка!Без цифр!");
        }
        var someStringValue = (string)value;
        return !_forbiddenStocks.Contains(someStringValue);
    }
}