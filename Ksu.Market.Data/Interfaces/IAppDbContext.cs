using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Microsoft.EntityFrameworkCore;

namespace Ksu.Market.Data.Interfaces
{
	public interface IAppDbContext : IDisposable
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<OperationResult> OperationResults { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Category> Categories { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}