using AutoMapper;
using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserEntity>();

            CreateMap<UserEntity, User>();
        }
    }
}
