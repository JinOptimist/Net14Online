using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class ForbidenStringsAttribute : ValidationAttribute
    {
        private string[] _forbidenStrings;

        public ForbidenStringsAttribute(params string[] forbidenStrings)
        {
            _forbidenStrings = forbidenStrings;
        }

        public override string FormatErrorMessage(string name)
        {
            var forbidenStringsWithQuotes = _forbidenStrings.Select(x => $"'{x}'");
            var forbidenStringsWithQuotesAndSpaces = string.Join(" ", forbidenStringsWithQuotes);

            return string.IsNullOrEmpty(ErrorMessage)
                ? $"Поле {name} не может быть равно {forbidenStringsWithQuotesAndSpaces}"
                : ErrorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is not null
                && value is not string)
            {
                throw new ArgumentException("ForbidenStringsAttribute can be only on string");
            }

            var someStringValue = (string)value;
            return !_forbidenStrings.Contains(someStringValue);
        }
    }
}
