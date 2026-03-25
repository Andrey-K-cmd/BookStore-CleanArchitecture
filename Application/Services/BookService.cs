using Application.Contracts.Store;
using Application.Interfaces;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<(Guid BookId, string Error)> CreateBook(BookRequest bookRequest)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                bookRequest.Title,
                bookRequest.Author,
                bookRequest.PublishingHouse,
                bookRequest.PublishingYear,
                bookRequest.CountPages,
                bookRequest.Price,
                bookRequest.Binding);

            if (!string.IsNullOrEmpty(error))
            {
                return (Guid.Empty, error);
            }

            var id = await _bookRepository.Create(book!);

            return (id, string.Empty);
        }

        public async Task<Guid> DeleteBook(Guid bookId)
        {
            return await _bookRepository.Delete(bookId);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<(Guid BookId, string Error)> UpdateBook(Guid id, BookRequest bookRequest)
        {
            var (book, error) = Book.Create(
                id,
                bookRequest.Title,
                bookRequest.Author,
                bookRequest.PublishingHouse,
                bookRequest.PublishingYear,
                bookRequest.CountPages,
                bookRequest.Price,
                bookRequest.Binding);

            if (!string.IsNullOrWhiteSpace(error))
            {
                return (Guid.Empty, error);
            }

            var updatedId = await _bookRepository.Update(book!);

            return (updatedId, string.Empty);
        }
    }
}
