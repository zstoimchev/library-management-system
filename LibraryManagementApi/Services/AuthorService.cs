using LibraryManagement.Dtos;
using LibraryManagement.Mappers;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<List<AuthorResponseDto>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.Select(item => item.ToAuthorResponse()).ToList();
    }

    public async Task<AuthorResponseDto> CreateAuthor(AuthorRequestDto authorRequestDto)
    {
        var author = authorRequestDto.ToAuthorFromRequest();
        var createdAuthor = await _authorRepository.CreateAsync(author);
        return createdAuthor.ToAuthorResponse();
    }
}