using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class ForbidenNameAttribure : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null
                || value is not string)
            {
                throw new ArgumentException("ForbidenNameAttribure can be only on string");
            }

            var someStringValue = (string)value;
            return !value.Equals("Запрещенка");
        }
    }
}
