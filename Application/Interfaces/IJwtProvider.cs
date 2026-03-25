using Core.Models;

namespace Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateTocken(User user);
    }
}
