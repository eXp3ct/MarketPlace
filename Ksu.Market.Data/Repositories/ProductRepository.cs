using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Data.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(IAppDbContext context, ILogger<BaseRepository<Product>> logger) : base(context, logger)
		{

		}

		public async Task<Product> UpdateRating(Guid id, float rating, CancellationToken cancellationToken = default)
		{
			var product = await GetByIdAsync(id, cancellationToken);

			product.Rating = rating;

			await SaveChangesAsync(cancellationToken);

			return product;
		}
	}
}
