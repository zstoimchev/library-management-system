using LibraryManagement.Dtos;
using LibraryManagement.Mappers;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookResponseDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.Select(item => item.ToBookResponse()).ToList();
    }

    public async Task<BookResponseDto> CreateBook(BookRequestDto bookRequestDto)
    {
        var book = bookRequestDto.ToBookFromRequest();
        var createdBook = await _bookRepository.CreateAsync(book);
        return createdBook.ToBookResponse();
    }

    public async Task<BookResponseDto?> UpdateBook(int id, BookRequestDto bookRequestDto)
    {
        var book = bookRequestDto.ToBookFromRequest();
        var updatedBook = await _bookRepository.UpdateAsync(id, book);
        return updatedBook?.ToBookResponse();
    }

    public async Task<BookResponseDto?> DeleteBook(int id)
    {
        var deletedBook = await _bookRepository.DeleteAsync(id);
        return deletedBook?.ToBookResponse();
    }
}