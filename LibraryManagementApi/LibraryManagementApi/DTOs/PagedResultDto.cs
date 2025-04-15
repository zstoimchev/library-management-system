namespace LibraryManagement.Dtos;

public class PagedResultDto<T>
{
    public List<T> Books { get; set; } = [];
    public int TotalBooks { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}