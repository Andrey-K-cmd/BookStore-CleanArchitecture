using Application.Contracts.Users;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(RegisterUserRequest request);
        Task<(string Token, string Error)> Login(LoginUserRequest request);
    }
}
