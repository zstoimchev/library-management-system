using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Validators;

public class TitleValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string title || string.IsNullOrWhiteSpace(title))
        {
            return new ValidationResult("Title cannot be empty or just spaces.");
        }

        return title.Length is < 5 or > 255
            ? new ValidationResult("Title must be between 5 and 255 characters.")
            : ValidationResult.Success;
    }
}