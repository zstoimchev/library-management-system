using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        this._context = context;
    }
    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> CreateAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }
    
}
