namespace LibraryManagement.Dtos;

public class BookRequestDto
{
    public string Title { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int AuthorId { get; set; }
}