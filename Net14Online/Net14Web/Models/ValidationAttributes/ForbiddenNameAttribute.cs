using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Net14Web.Models.ValidationAttributes
{
    public class ForbiddenNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            if (value is not string || value is null)
            {
                throw new ArgumentException("Name can be only string");
            }

            var stringValue = (string)value;

            return !Regex.IsMatch(stringValue, @"\d+");
        }
    }
}
