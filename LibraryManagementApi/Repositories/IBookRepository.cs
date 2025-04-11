using LibraryManagement.Models;

namespace LibraryManagement.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> CreateAsync(Book book);
    Task<Book?> UpdateAsync(int id, Book book);
    Task<Book?> DeleteAsync(int id);
}