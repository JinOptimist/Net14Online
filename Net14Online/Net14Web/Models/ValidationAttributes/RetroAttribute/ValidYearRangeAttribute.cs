using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ValidYearRangeAttribute : ValidationAttribute
{
    private readonly int _minYear;

    public ValidYearRangeAttribute()
    {
        _minYear = 1960;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            int year = (int)value;
            int currentYear = DateTime.Now.Year;

            if (year < _minYear || year > currentYear)
            {
                return new ValidationResult($"Год должен быть в диапазоне {_minYear}-{currentYear}.");
            }
        }

        return ValidationResult.Success;
    }
}
