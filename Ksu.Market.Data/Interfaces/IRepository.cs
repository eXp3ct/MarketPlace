using Ksu.Market.Domain.Interfaces;
using Ksu.Market.Domain.Models;
using System.Linq.Expressions;

namespace Ksu.Market.Data.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : IHaveId
	{
		public Task<TEntity> GetByIdAsync(Guid id, CancellationToken canecllationToken = default);

		public Task<IEnumerable<TEntity>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default);

		public Task<TEntity> Create(TEntity entity, CancellationToken canecllationToken = default);

		public Task<TEntity> Delete(Guid id, CancellationToken canecllationToken = default);


		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}

	public interface IProductRepository : IRepository<Product>
	{
		public Task<Product> UpdateRating(Guid id, float rating, CancellationToken cancellationToken = default);
	}
}