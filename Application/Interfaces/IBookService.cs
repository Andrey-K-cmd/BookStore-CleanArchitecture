using Application.Contracts.Store;
using Core.Models;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<(Guid BookId, string Error)> CreateBook(BookRequest book);
        Task<(Guid BookId, string Error)> UpdateBook(Guid id, BookRequest book);
        Task<Guid> DeleteBook(Guid bookId);
    }
}
