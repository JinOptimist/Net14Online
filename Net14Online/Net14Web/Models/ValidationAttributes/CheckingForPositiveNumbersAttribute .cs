using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class CheckingForPositiveNumbersAttribute : ValidationAttribute
    {
     
        public override bool IsValid(object? value)
        {

            if (value is not null && value is not int)
            {
                throw new ArgumentException("Это не число!");
            }
            var someIntValue = (int)value;
            return someIntValue>0;
        }
    }
}
