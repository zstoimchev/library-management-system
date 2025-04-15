namespace LibraryManagement.Dtos;

public class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int AuthorId { get; set; }
}