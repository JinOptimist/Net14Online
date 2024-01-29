using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Net14Web.Models.ValidationAttributes
{
    public class TaskTrackerValidationAttribute : ValidationAttribute
    {
        private readonly Regex _regex;

        public TaskTrackerValidationAttribute()
        {
            _regex = new Regex(@"^[a-zA-Z0-9]*$");
        }

        public override bool IsValid(object? value)
        {
          
            if (value is not null && value is not string)
            {
                throw new ArgumentException("TaskTrackerValidationAttribute can be only on string");
            }

            var someStringValue = (string)value;
            return _regex.IsMatch(someStringValue);
        }
    }
}
