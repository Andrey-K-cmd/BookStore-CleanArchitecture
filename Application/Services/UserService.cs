using Application.Interfaces;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public UserService(IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<string> Login(string email, string password)
        {

            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PaasswordHash);

            if (result == false)
            {
                return "Проверьте введенные данные";
            }

            return "";
        }

        public async Task Register(string name, string email, string password)
        {
            var hash = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), name, email, hash).user;

            await _userRepository.Add(user);
        }
    }
}
