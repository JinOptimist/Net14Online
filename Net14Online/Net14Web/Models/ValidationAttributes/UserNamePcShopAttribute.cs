using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Net14Web.Models.ValidationAttributes
{
    public class UserNamePcShopAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            if (value is not string)
            {
                throw new ArgumentException("Не туда повесил аттрибут. Можем работать только с String");
            }

            var userName = (string)value;
            if (Regex.IsMatch(userName, ".*\\d+.*"))
            {
                return false;
            }

            return true;
        }
    }
}