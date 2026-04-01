using Application.Contracts.Store;
using Application.Interfaces;
using Application.Contracts.Validators;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookValidator _bookValidator;

        public BookService(IBookRepository bookRepository, BookValidator validations)
        {
            _bookRepository = bookRepository;
            _bookValidator = validations;
        }

        public async Task<(Guid BookId, string Error)> CreateBook(BookRequest bookRequest)
        {
            var validation = await _bookValidator.ValidateAsync(bookRequest);

            if (!validation.IsValid)
            {
                var error = validation.Errors.First().ErrorMessage;
                return (Guid.Empty, error);
            }

            var book = Book.Create(
                Guid.NewGuid(),
                bookRequest.Title,
                bookRequest.Author,
                bookRequest.PublishingHouse,
                bookRequest.PublishingYear,
                bookRequest.CountPages,
                bookRequest.Price,
                bookRequest.Binding);

            await _bookRepository.Create(book);

            return (book.Id, string.Empty);
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
            var validation = await _bookValidator.ValidateAsync(bookRequest);

            if (!validation.IsValid)
            {
                var error = validation.Errors.First().ErrorMessage;
                return (Guid.Empty, error);
            }

            var book = Book.Create(
                id,
                bookRequest.Title,
                bookRequest.Author,
                bookRequest.PublishingHouse,
                bookRequest.PublishingYear,
                bookRequest.CountPages,
                bookRequest.Price,
                bookRequest.Binding);

            var updateId = await _bookRepository.Update(book);

            return (updateId, string.Empty);
        }
    }
}
