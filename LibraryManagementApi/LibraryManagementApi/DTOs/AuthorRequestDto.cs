using LibraryManagement.Validators;
using Microsoft.Build.Framework;

namespace LibraryManagement.Dtos;

public class AuthorRequestDto
{
    [Required] [NameValidation] public string Name { get; set; } = string.Empty;
    [Required] [DoBValidation] public DateTime DateOfBirth { get; set; }
}