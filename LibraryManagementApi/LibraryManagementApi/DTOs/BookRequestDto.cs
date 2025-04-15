using System.ComponentModel.DataAnnotations;
using LibraryManagement.Validators;

namespace LibraryManagement.Dtos;

public class BookRequestDto
{
    [Required] [TitleValidation] public string Title { get; set; } = string.Empty;

    [Required] [YearValidation] public int PublicationYear { get; set; }

    [Required] public int AuthorId { get; set; }
}