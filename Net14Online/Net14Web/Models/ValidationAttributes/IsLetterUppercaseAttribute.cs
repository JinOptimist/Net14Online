using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class IsLetterUppercaseAttribute : ValidationAttribute
    {
        private int _countValidLetters;

        public IsLetterUppercaseAttribute(int countValidLetters)
        {
            _countValidLetters = countValidLetters;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"Пароль должен иметь минимум {_countValidLetters} буквы верхнего регистра!"
                : ErrorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is not null
                && value is not string)
            {
                throw new ArgumentException("IsLetterUppercaseAttribute can be only on string");
            }

            if (value is null)
            {
                return false;
            }

            var someStringValue = (string)value;

            if (someStringValue == "")
            {
                return false;
            }

            return IsStringHaveWordUpper(someStringValue);
        }

        private bool IsStringHaveWordUpper(string someStringValue)
        {
            int countValidLetters = 0;
            foreach (char c in someStringValue)
            {
                if (char.IsUpper(c))
                {
                    countValidLetters++;
                }
            }
            if (countValidLetters >= _countValidLetters)
            {
                return true;
            }
            return false;
        }
    }
}
