using FuzzySharp;
using LibraryManagement.Data;
using LibraryManagement.Dtos;
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

    public async Task<PagedResultDto<Book>> GetAllAsync(int pageNumber, int pageSize)
    {
        var totalItems = await _context.Books.CountAsync();
        var books = await _context.Books
            .OrderBy(item => item.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PagedResultDto<Book>
        {
            Books = books,
            TotalBooks = totalItems,
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
            CurrentPage = pageNumber,
            PageSize = pageSize
        };
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
        var allBooks = await _context.Books.ToListAsync();
        var matchedBooks = new List<Book>();

        foreach (var book in allBooks)
        {
            if (book.Title.ToLower().Contains(query.ToLower()))
            {
                matchedBooks.Add(book);
                continue;
            }

            var ratio = Fuzz.Ratio(query.ToLower(), book.Title.ToLower());
            if (ratio >= 80)
            {
                matchedBooks.Add(book);
            }
        }

        return matchedBooks;
    }
}