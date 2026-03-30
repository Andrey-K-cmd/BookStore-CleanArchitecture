using Application.Interfaces;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IPasswordHasher passwordHasher, 
            IUserRepository userRepository, 
            IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string email, string password)
        {

            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                return "Проверьте введенные данные";
            }

            var token = _jwtProvider.GenerateTocken(user);

            return token;
        }

        public async Task Register(string name, string email, string password)
        {
            var hash = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), name, email, hash, Role.User).user;

            await _userRepository.Add(user);
        }
    }
}
