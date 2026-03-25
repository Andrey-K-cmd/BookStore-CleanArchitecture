using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            var user = _mapper.Map<User>(userEntity);
            return user;
        }
    }
}
