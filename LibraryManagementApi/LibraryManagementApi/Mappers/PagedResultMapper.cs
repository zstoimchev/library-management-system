using LibraryManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.Mappers;

public static class PagedResultMapper
{
    public static PagedResultDto<BookResponseDto> ToPagedResponse(PagedResultDto<Book> source)
    {
        return new PagedResultDto<BookResponseDto>
        {
            Books = source.Books.Select(b => b.ToBookResponse()).ToList(),
            TotalBooks = source.TotalBooks,
            TotalPages = source.TotalPages,
            CurrentPage = source.CurrentPage,
            PageSize = source.PageSize
        };
    }
}