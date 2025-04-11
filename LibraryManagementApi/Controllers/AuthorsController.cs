using LibraryManagement.Dtos;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _authorService;

    public AuthorsController(AuthorService authorService)
    {
        this._authorService = authorService;
    }

    // GET /authors: Fetch a list of all authors
    [HttpGet]
    public async Task<ActionResult<List<AuthorResponseDto>>> GetAllAuthors()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        return authors.Count != 0 ? Ok(authors) : NotFound();
    }

    // POST /authors: Add a new author
    [HttpPost]
    public async Task<ActionResult<AuthorResponseDto>> Create([FromBody] AuthorRequestDto authorRequestDto)
    {
        var createdAuthor = await _authorService.CreateAuthor(authorRequestDto);
        return CreatedAtAction(nameof(GetAllAuthors), new { id = createdAuthor.Id }, createdAuthor);
    }
}