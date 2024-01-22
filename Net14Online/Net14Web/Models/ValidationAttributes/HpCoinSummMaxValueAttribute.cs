using Net14Web.Models.Dnd;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.ValidationAttributes
{
    public class HpCoinSummMaxValueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is not AddHeroViewModel)
            {
                throw new ArgumentException("Не туда повесил аттрибут. Можем работать только с AddHeroViewModel");
            }

            var addHeroViewModel = (AddHeroViewModel)validationContext.ObjectInstance;
            if (addHeroViewModel.Hp + addHeroViewModel.Coin > 10)
            {
                return new ValidationResult("Слишком много Хп и Денег");
            }

            return ValidationResult.Success;
        }
    }
}
