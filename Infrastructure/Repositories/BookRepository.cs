using Core.Interfaces;
using Core.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntities = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishingHouse = book.PublishingHouse,
                PublishingYear = book.PublishingYear,
                CountPages = book.CountPages,
                Price = book.Price,
                Binding = book.Binding
            };

            await _dbContext.Books.AddAsync(bookEntities);
            await _dbContext.SaveChangesAsync();

            return bookEntities.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Books.Where(book => book.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public async Task<List<Book>> GetAll()
        {
            var bookEntities = await _dbContext.Books.
                AsNoTracking().ToListAsync();

            var books = bookEntities.Select(b => Book
            .Create(b.Id, b.Title, b.Author, b.PublishingHouse, 
            b.PublishingYear, b.CountPages, b.Price, b.Binding)).ToList();

            return books;
        }

        public async Task<Guid> Update(Book book)
        {
            await _dbContext.Books
                .Where(b => b.Id == book.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => book.Title)
                .SetProperty(b => b.Author, b => book.Author)
                .SetProperty(b => b.PublishingHouse, b => book.PublishingHouse)
                .SetProperty(b => b.PublishingYear, b => book.PublishingYear)
                .SetProperty(b => b.CountPages, b => book.CountPages)
                .SetProperty(b => b.Price, b => book.Price)
                .SetProperty(b => b.Binding, b => book.Binding));

            return book.Id;
        }
    }
}
