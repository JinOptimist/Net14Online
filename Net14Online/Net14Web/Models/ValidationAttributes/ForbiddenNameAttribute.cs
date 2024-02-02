using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class ForbiddenNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            if (value is not string && value is not null)
            {
                throw new ArgumentException("ForbidenSymbolsAttribute can be only string");
            }

            var stringValue = (string)value;
            return stringValue != "Name";
        }
    }
}
