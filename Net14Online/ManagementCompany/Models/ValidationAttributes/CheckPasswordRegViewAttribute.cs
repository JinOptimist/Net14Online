using System.ComponentModel.DataAnnotations;

namespace ManagementCompany.Models.ValidationAttributes
{
    public class CheckPasswordRegViewAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is not Models.RegistrationViewModel)
            {
                throw new ArgumentException("Работает только с RegistrationViewModel");
            }

            var RegistrationViewModel = (RegistrationViewModel)validationContext.ObjectInstance;

            if (RegistrationViewModel.Password is null)
            {
                return new ValidationResult("Пароль не может быть пустым");
            }
            if (RegistrationViewModel.NickName is null)
            {
                return new ValidationResult("Ник не может быть пустым");
            }
            if (RegistrationViewModel.Email is null)
            {
                return new ValidationResult("Почта не может быть пустой");
            }
            if (RegistrationViewModel.Password.Contains(RegistrationViewModel.NickName) || RegistrationViewModel.Password.Contains(RegistrationViewModel.Email.Split("@")[0]))
            {
                return new ValidationResult("Пароль не должен содержать значений ника или почты");
            }

            return ValidationResult.Success;
        }
    }
}
