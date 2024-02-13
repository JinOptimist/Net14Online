using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class IsLetterNumberAttribute : ValidationAttribute
    {
        private int _countValidLetters;

        public IsLetterNumberAttribute(int countValidLetters)
        {
            _countValidLetters = countValidLetters;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"Пароль должен иметь минимум {_countValidLetters} цифры!"
                : ErrorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is not string)
            {
                throw new ArgumentException("IsLetterNumberAttribute can be only on string");
            }
            var someStringValue = (string)value;
            if (someStringValue == "")
            {
                return false;
            }
            return IsStringHaveWordNumber(someStringValue);
        }

        private bool IsStringHaveWordNumber(string someStringValue)
        {
            int countValidLetters = someStringValue.Where(c => char.IsDigit(c)).Count();
            return countValidLetters >= _countValidLetters;
        }
    }
}
