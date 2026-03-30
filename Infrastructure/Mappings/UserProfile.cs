using AutoMapper;
using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserEntity>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => (int)src.Role));

            CreateMap<UserEntity, User>()
                .ConstructUsing(src => User.Create(
                    src.Id,
                    src.Name,
                    src.Email,
                    src.PasswordHash,
                    (Role)src.RoleId
                ).user!);
        }
    }
}
