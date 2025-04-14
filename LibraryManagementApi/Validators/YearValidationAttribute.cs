using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Validators;

public class YearValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not int year)
        {
            return new ValidationResult("Publication Year is required.");
        }

        return year >= DateTime.UtcNow.Year
            ? new ValidationResult("Publication Year must be before the current year.")
            : ValidationResult.Success;
    }
}