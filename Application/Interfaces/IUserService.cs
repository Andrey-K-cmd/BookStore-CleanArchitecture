namespace Application.Interfaces
{
    public interface IUserService
    {
        Task Register(string name, string email, string password);
        Task<string> Login(string email, string password);
    }
}
