using LibraryManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.Mappers;

public static class BookMappers
{
    public static Book ToBookFromRequest(this BookRequestDto bookRequestDto)
    {
        return new Book
        {
            Title = bookRequestDto.Title,
            PublicationYear = bookRequestDto.PublicationYear,
            AuthorId = bookRequestDto.AuthorId
        };
    }

    public static BookResponseDto ToBookResponse(this Book book)
    {
        return new BookResponseDto
        {
            Id = book.Id,
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            AuthorId = book.AuthorId
        };
    }
    
}