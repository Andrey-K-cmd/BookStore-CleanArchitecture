using AutoMapper;
using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookEntity>();

            CreateMap<BookEntity, Book>()
                .ConstructUsing(src => Book.Create(
                    src.Id,
                    src.Title,
                    src.Author,
                    src.PublishingHouse,
                    src.PublishingYear,
                    src.CountPages,
                    src.Price,
                    src.Binding
                ));
        }
    }
}
