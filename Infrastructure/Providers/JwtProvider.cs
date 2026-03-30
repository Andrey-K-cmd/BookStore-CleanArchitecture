using Application.Interfaces;
using Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Providers
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string GenerateTocken(User user)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
