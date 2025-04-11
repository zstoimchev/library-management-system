using LibraryManagement.Models;

namespace LibraryManagement.Repositories;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync();
    Task<Author> CreateAsync(Author author);
}
