using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Validators;

public class NameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string name || string.IsNullOrWhiteSpace(name))
        {
            return new ValidationResult("Name cannot be empty or just spaces.");
        }

        return name.Length is < 5 or > 255
            ? new ValidationResult("Name must be between 5 and 255 characters.")
            : ValidationResult.Success;
    }
}