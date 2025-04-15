using System.Threading.Tasks;
using JetBrains.Annotations;
using LibraryManagement.Dtos;
using LibraryManagement.Mappers;
using LibraryManagement.Repositories;
using LibraryManagement.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LibraryManagementApi.Tests.Services;

[TestClass]
[TestSubject(typeof(BookService))]
public class BookServiceTest
{
    private Mock<IBookRepository> _bookRepositoryMock;
    private BookService _bookService;

    [TestInitialize]
    public void Setup()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _bookService = new BookService(_bookRepositoryMock.Object);
    }

    [TestMethod]
    public async Task CreateBook_ShouldReturnCreatedBookResponse()
    {
        // Arrange
        var requestDto = new BookRequestDto { Title = "Test Book", PublicationYear = 2020 };
        var book = requestDto.ToBookFromRequest();
        var expectedResponse = book.ToBookResponse();

        _bookRepositoryMock.Setup(repo => repo.CreateAsync(book))
            .ReturnsAsync(book);

        // Act
        var actualResponse = await _bookService.CreateBook(requestDto);

        // Assert
        Assert.IsNotNull(actualResponse);
        Assert.AreEqual(expectedResponse.Title, actualResponse.Title);
        Assert.AreEqual(expectedResponse.PublicationYear, actualResponse.PublicationYear);
    }
}