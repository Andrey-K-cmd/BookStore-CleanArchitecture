using Infrastructure.Bootstrapper;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}
