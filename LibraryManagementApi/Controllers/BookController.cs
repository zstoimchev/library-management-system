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
    public async Task<ActionResult<List<BookResponseDto>>> GetAllBooks([FromQuery] int pageNumber,
        [FromQuery] int pageSize)
    {
        var books = await _bookService.GetAllBooksAsync(pageNumber, pageSize);
        return books.Books.Count != 0 ? Ok(books) : NotFound();
    }

    // POST /books: Add a new book
    [HttpPost]
    public async Task<ActionResult<BookResponseDto>> Create([FromBody] BookRequestDto bookRequestDto)
    {
        var createdBook = await _bookService.CreateBook(bookRequestDto);
        return CreatedAtAction(nameof(GetAllBooks), new { id = createdBook.Id }, createdBook);
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // PUT /books/{id}: Update an existing book's details
    [HttpPut("{id:int}")]
    public async Task<ActionResult<BookResponseDto>> UpdateBook([FromRoute] int id,
        [FromBody] BookRequestDto bookRequestDto)
    {
        var book = await _bookService.UpdateBook(id, bookRequestDto);
        return book is not null ? Ok(book) : NotFound();
    }

    // DELETE /books/{id}: Delete a book by its ID
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        var book = await _bookService.DeleteBook(id);
        return book is not null ? NoContent() : NotFound();
    }

    // GET /books/search?query=<query>: Search for books by title using a similarity search
    [HttpGet("search")]
    public async Task<ActionResult<List<BookResponseDto>>> SearchBooks([FromQuery] string query)
    {
        var books = await _bookService.SearchBooksAsync(query);
        return books.Count > 0 ? Ok(books) : NotFound();
    }
}