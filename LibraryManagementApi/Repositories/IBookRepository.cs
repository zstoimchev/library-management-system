using LibraryManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories;

public interface IBookRepository
{
    Task<PagedResultDto<Book>> GetAllAsync(int pageNumber, int pageSize);
    Task<Book> CreateAsync(Book book);
    Task<Book?> UpdateAsync(int id, Book book);
    Task<Book?> DeleteAsync(int id);
    Task<List<Book>> SearchAsync(string query);
}