using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntities = _mapper.Map<BookEntity>(book);

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

            return _mapper.Map<List<Book>>(bookEntities);
        }

        public async Task<List<Book>> GetByFilter(BookFilter bookFilter)
        {
            var query = _dbContext.Books.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(bookFilter.Title))
                query = query.Where(b => b.Title.Contains(bookFilter.Title));

            if (!string.IsNullOrWhiteSpace(bookFilter.Author))
                query = query.Where(b => b.Author.Contains(bookFilter.Author));

            if (bookFilter.MinPrice.HasValue)
                query = query.Where(b => b.Price >= bookFilter.MinPrice);

            if (!string.IsNullOrWhiteSpace(bookFilter.Binding))
                query = query.Where(b => b.Binding.Contains(bookFilter.Binding));

            var entities = await query.ToListAsync();

            return _mapper.Map<List<Book>>(entities);
        }

        public async Task<Guid> Update(Book book)
        {
            var entity = await _dbContext.Books.FindAsync(book.Id);

            if (entity != null)
            {
                _mapper.Map(book, entity);
                await _dbContext.SaveChangesAsync();
            }

            return book.Id;
        }
    }
}
