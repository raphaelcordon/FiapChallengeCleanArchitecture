using System.ComponentModel.DataAnnotations;

namespace Application.Common;

public class DateAfterTodayAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateOnly date)
        {
            if (date > DateOnly.FromDateTime(DateTime.Today))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The date must be after today's date.");
            }
        }
        return new ValidationResult("Invalid date format.");
    }
}