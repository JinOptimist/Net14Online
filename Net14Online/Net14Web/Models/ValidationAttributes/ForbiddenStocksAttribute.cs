using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class ForbiddenStocksAttribute : ValidationAttribute
    {
        private string[] _forbiddenStocks;

        public ForbiddenStocksAttribute(params string[] forbiddenStocks) 
        { 
            _forbiddenStocks = forbiddenStocks;
        }
        public override bool IsValid(object? value)
        {

            if (value is not null && value is not string)
            {
                throw new ArgumentException("Нужна строка!");
            }
            var someStringValue = (string)value;
            return !_forbiddenStocks.Contains(someStringValue);
        }
    }
}
