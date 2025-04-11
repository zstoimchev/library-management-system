using LibraryManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.Mappers;

public static class AuthorMappers
{
    public static Author ToAuthorFromRequest(this AuthorRequestDto author)
    {
        return new Author
        {
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }

    public static AuthorResponseDto ToAuthorResponse(this Author author)
    {
        return new AuthorResponseDto
        {
            Id = author.Id,
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }
}