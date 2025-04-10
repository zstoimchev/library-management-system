using LibraryManagement.Data;
using LibraryManagement.Dtos;
using LibraryManagement.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AuthorsController(ApplicationDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = _context.Authors.ToList()
            .Select(item => item.ToAuthorDto());
        return Ok(authors);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AuthorRequest author)
    {
        var authorModel = author.ToAuthorFromRequest();
        _context.Authors.Add(authorModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = authorModel.Id }, authorModel);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var author = _context.Authors.Find(id);
        if (author == null)
            return NotFound();

        return Ok(author.ToAuthorDto());
    }
}
