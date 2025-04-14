using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Validators;

public class DoBValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not int year)
        {
            return new ValidationResult("Date of Birth Year is required.");
        }

        return year >= DateTime.UtcNow.Year
            ? new ValidationResult("Date of Birth Year must be before the current year.")
            : ValidationResult.Success;
    }
    
}