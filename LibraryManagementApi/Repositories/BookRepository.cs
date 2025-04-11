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

    public async Task<Book?> UpdateAsync(int id, Book book)
    {
        var bookToUpdate = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (bookToUpdate is null)
        {
            return null;
        }

        bookToUpdate.Title = book.Title;
        bookToUpdate.PublicationYear = book.PublicationYear;
        bookToUpdate.AuthorId = book.AuthorId;
        await _context.SaveChangesAsync();
        return bookToUpdate;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book is null)
        {
            return null;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<List<Book>> SearchAsync(string query)
    {
        var queryResult = _context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query))
            queryResult = queryResult.Where(b => b.Title.Contains(query));
        
        return await queryResult.ToListAsync();
    }
}