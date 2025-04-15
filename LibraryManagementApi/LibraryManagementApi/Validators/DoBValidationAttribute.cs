using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Validators;

public class DoBValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dateOfBirth)
        {
            return new ValidationResult("Invalid date format. Date of Birth must be a valid DateTime.");
        }

        return dateOfBirth.Year >= DateTime.UtcNow.Year
            ? new ValidationResult("Date of Birth Year must be before the current year.")
            : ValidationResult.Success;
    }
    
}