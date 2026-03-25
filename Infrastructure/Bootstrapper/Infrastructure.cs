using Infrastructure.Mappings;
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

            services.AddAutoMapper(c => c.AddProfile<UserProfile>());

            return services;
        }
    }
}
