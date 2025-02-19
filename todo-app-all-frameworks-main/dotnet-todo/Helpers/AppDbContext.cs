using dotnet_todo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_todo.Helpers;

	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
				: base(options)
		{
		}

		public DbSet<Tasks>? Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tasks>()
                    .ToTable("Tasks")
                    .HasIndex(t => t.Name)
                    .IsUnique();
                    
        modelBuilder.Entity<Tasks>().ToTable("Tasks")
        .Property(t => t.Status)
        .HasConversion(
            v => v.ToString(),
            v => (TasksStatusEnum)Enum.Parse(typeof(TasksStatusEnum), v)
        );
        }
        

	}