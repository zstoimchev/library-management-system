using LibraryManagement.Models;

namespace LibraryManagement.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> CreateAsync(Book book);
}