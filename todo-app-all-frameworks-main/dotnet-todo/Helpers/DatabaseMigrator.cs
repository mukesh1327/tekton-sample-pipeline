// using dotnet_todo.Helpers;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// public class DatabaseMigrator : IDesignTimeDbContextFactory<AppDbContext>
// {

//     private readonly IConfiguration _configuration;

//     public DatabaseMigrator(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }
//     public AppDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//         var connectionString = _configuration.GetConnectionString("PostgreSQL");
//         optionsBuilder.UseNpgsql(connectionString);
//         return new AppDbContext(optionsBuilder.Options);
//     }

// public static void MigrateDatabase(IConfiguration configuration)
// {
//     try
//     {
//         var serviceProvider = new ServiceCollection()
//             .AddDbContext<AppDbContext>(options =>
//             {
//                 var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//                 var connectionString = configuration.GetConnectionString("PostgreSQL"); // Retrieve the connection string from the configuration
//                 optionsBuilder.UseNpgsql(connectionString);
//             })
//             .BuildServiceProvider();

//         using (var scope = serviceProvider.CreateScope())
//         {
//             var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//             context.Database.Migrate();
//         }

//         Console.WriteLine("Database migration completed successfully.");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error migrating the database: {ex.Message}");
//     }
// }
// }