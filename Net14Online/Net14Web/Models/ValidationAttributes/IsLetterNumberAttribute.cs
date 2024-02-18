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
            if (value is not null
                && value is not string)
            {
                throw new ArgumentException("IsLetterNumberAttribute can be only on string");
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

            return IsStringHaveWordNumber(someStringValue);
        }

        private bool IsStringHaveWordNumber(string someStringValue)
        {
            int countValidLetters = 0;
            foreach (char c in someStringValue)
            {
                if (char.IsDigit(c))
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
