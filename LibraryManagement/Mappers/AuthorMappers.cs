using LibraryManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.Mappers;

public static class AuthorMappers
{
    public static AuthorDto ToAuthorDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }

    public static Author ToAuthorFromRequest(this AuthorRequest author)
    {
        return new Author
        {
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }
}