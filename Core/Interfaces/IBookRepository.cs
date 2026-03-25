using Core.Models;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Update(Book book);
        Task<List<Book>> GetAll();
        Task<Guid> Delete (Guid id);
    }
}
