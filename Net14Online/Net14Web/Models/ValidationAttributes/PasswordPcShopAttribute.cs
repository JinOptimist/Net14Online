using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Net14Web.Models.ValidationAttributes
{
    public class PasswordPcShopAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            if (value is not string)
            {
                throw new ArgumentException("Не туда повесил аттрибут. Можем работать только с String");
            }

            var password = (string)value;
            if (!Regex.IsMatch(password, ".*[a-zа-я]+.*"))
            {
                return false;
            }
            
            if (!Regex.IsMatch(password, ".*[A-ZА-Я]+.*"))
            {
                return false;
            }
            
            if (!Regex.IsMatch(password, ".*\\d+.*"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, ".*[\\p{P}]+.*"))
            {
                return false;
            }
            return true;
        }
    }
}
