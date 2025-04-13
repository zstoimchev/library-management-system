namespace LibraryManagement.Dtos;

public class AuthorRequestDto
{
    // TODO: Add validation attributes
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}
