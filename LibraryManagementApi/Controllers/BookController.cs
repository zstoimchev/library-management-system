using LibraryManagement.Dtos;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers;

[Route("books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        this._bookService = bookService;
    }

    // GET /books: Fetch a paginated list of books
    [HttpGet]
    public async Task<ActionResult<List<BookResponseDto>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return books.Count != 0 ? Ok(books) : NotFound();
    }

    // POST /books: Add a new book
    [HttpPost]
    public async Task<ActionResult<BookResponseDto>> Create([FromBody] BookRequestDto bookRequestDto)
    {
        // return Ok(await _bookService.CreateBook(bookDto));
        var createdBook = await _bookService.CreateBook(bookRequestDto);
        return CreatedAtAction(nameof(GetAllBooks), new { id = createdBook.Id }, createdBook);
    }

    // PUT /books/{id}: Update an existing book's details
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookDto bookDto)
    // {
    //     var book = await _bookService.UpdateBook(id, bookDto);
    //     return Ok(book);
    // }

    // DELETE /books/{id}: Delete a book by its ID
    // [HttpDelete("{id}")]
    // public Task<IActionResult> DeleteBook(int id)
    // {
    // }


    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpGet("{id}")]
    // public async Task<ActionResult<Book>> CreateBook(BookDto bookDto)
    // {
    //     var book = await _bookService.CreateBook(bookDto);
    //     return Created("", book);
    // }

    // private bool BookExists(int id)
    // {
    //     return _context.Books.Any(e => e.Id == id);
    // }
}