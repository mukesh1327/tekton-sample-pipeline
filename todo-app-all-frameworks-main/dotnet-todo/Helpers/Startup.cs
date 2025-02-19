using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;
using dotnet_todo.Repository;
using dotnet_todo.Service;

namespace dotnet_todo.Helpers;

public class Startup{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();

            services.AddScoped<ITasksService, TasksService>();

            services.AddControllers().AddJsonOptions(options =>
            {
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            TasksRepository.Configure(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
    using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
        dbContext?.Database.Migrate();
    }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
}