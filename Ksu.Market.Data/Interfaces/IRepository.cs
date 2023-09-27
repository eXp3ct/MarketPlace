using Ksu.Market.Domain.Interfaces;
using Ksu.Market.Domain.Models;

namespace Ksu.Market.Data.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : IHaveId
	{
		public Task<TEntity> GetByIdAsync(Guid id, CancellationToken canecllationToken = default);

		public Task<IQueryable<TEntity>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default);

		public Task<TEntity> Create(TEntity entity, CancellationToken canecllationToken = default);

		public Task<TEntity> Update(Guid id, TEntity entity, CancellationToken canecllationToken = default);

		public Task<TEntity> Delete(Guid id, CancellationToken canecllationToken = default);
	}

	public interface IRepository : IRepository<Product>
	{
		public Task<Product> UpdateRating(Guid id, float rating, CancellationToken cancellationToken = default);
	}
}