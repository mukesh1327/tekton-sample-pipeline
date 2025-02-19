using dotnet_todo.Helpers;
using Microsoft.EntityFrameworkCore;

namespace dotnet_todo.Repository
{
    public static class TasksRepository
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString)
            );
        }
    }
}