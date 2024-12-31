using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
	{
	}

	public DbSet<Article> Articles { get; set; }
	public DbSet<Author> Authors { get; set; }
	public DbSet<Category> Categories { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		OnModelCreatingPartial(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
