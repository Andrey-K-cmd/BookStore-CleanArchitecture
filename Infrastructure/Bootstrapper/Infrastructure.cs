using Application.Interfaces;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Mappings;
using Infrastructure.Providers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Bootstrapper
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<BookStoreDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));

            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddAutoMapper(c => c.AddProfile<UserProfile>());

            return services;
        }
    }
}
