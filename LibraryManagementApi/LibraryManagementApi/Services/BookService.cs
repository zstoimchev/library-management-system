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

    public async Task<PagedResultDto<BookResponseDto>> GetAllBooksAsync(int pageNumber, int pageSize)
    {
        var books = await _bookRepository.GetAllAsync(pageNumber, pageSize);
        return PagedResultMapper.ToPagedResponse(books);
        // return books.Select(item => item.ToBookResponse()).ToList();
    }

    public async Task<BookResponseDto> CreateBook(BookRequestDto bookRequestDto)
    {
        // TODO: Validate the request
        var book = bookRequestDto.ToBookFromRequest();
        var createdBook = await _bookRepository.CreateAsync(book);
        return createdBook.ToBookResponse();
    }

    public async Task<BookResponseDto?> UpdateBook(int id, BookRequestDto bookRequestDto)
    {
        // TODO: Validate the request
        var book = bookRequestDto.ToBookFromRequest();
        var updatedBook = await _bookRepository.UpdateAsync(id, book);
        return updatedBook?.ToBookResponse();
    }

    public async Task<BookResponseDto?> DeleteBook(int id)
    {
        // TODO: Validate the request
        // check if the book exists with that id, then delete
        var deletedBook = await _bookRepository.DeleteAsync(id);
        return deletedBook?.ToBookResponse();
    }

    public async Task<List<BookResponseDto>> SearchBooksAsync(string query)
    {
        var books = await _bookRepository.SearchAsync(query);
        return books.Select(b => b.ToBookResponse()).ToList();
    }
}