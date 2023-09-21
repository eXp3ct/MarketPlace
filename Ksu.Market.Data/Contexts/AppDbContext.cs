using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Microsoft.EntityFrameworkCore;

namespace Ksu.Market.Data.Contexts
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<OperationResult> OperationResults { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Category> Categories { get; set; }

		public AppDbContext()
		{
		}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var conntextionString = "Host=postgres;Port=5432;Database=postgres;Username=root;Password=root;";
			optionsBuilder.UseNpgsql(conntextionString);
		}
	}
}