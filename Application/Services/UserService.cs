using Application.Contracts.Users;
using Application.Contracts.Validators;
using Application.Interfaces;
using Core.Interfaces;
using Core.Models;
using FluentValidation;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IValidator<RegisterUserRequest> _registerValidator;
        private readonly IValidator<LoginUserRequest> _loginValidator;

        public UserService(IPasswordHasher passwordHasher, 
            IUserRepository userRepository, 
            IJwtProvider jwtProvider,
            IValidator<RegisterUserRequest> validations,
            IValidator<LoginUserRequest> validations1)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _registerValidator = validations;
            _loginValidator = validations1;
        }

        public async Task<(string Token, string Error)> Login(LoginUserRequest request)
        {
            string error = string.Empty;
            var validation = await _loginValidator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                error = string.Join(", ", validation.Errors.Select(e => e.ErrorMessage));
                return (string.Empty, error);
            }

            var user = await _userRepository.GetByEmail(request.Email);

            var result = _passwordHasher.Verify(request.Password, user.PasswordHash);

            if (result == false)
            {
                error = "Проверьте введенные данные";
                return (string.Empty, error);
            }

            var token = _jwtProvider.GenerateTocken(user);

            return (token, error);
        }

        public async Task<string> Register(RegisterUserRequest request)
        {
            var validation = await _registerValidator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                return string.Join(", ", validation.Errors.Select(e => e.ErrorMessage));
            }

            var hash = _passwordHasher.Generate(request.Password);

            var user = User.Create(Guid.NewGuid(), request.Name, request.Email, hash, Role.User);

            await _userRepository.Add(user);

            return string.Empty;
        }
    }
}
