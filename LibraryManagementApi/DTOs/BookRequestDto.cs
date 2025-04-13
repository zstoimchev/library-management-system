namespace LibraryManagement.Dtos;

public class BookRequestDto
{
    // TODO: Add validation attributes
    public string Title { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int AuthorId { get; set; }
}