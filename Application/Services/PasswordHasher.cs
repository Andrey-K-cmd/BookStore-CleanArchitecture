using Application.Interfaces;

namespace Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)
        {
            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            return hash;
        }

        public bool Verify(string password, string hash)
        {
            var result = BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
            return result;
        }
    }
}
