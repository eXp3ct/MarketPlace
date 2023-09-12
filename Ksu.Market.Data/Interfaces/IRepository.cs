using Ksu.Market.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ksu.Market.Data.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : IHaveId
	{
		public Task<TEntity> GetByIdAsync(Guid id, CancellationToken canecllationToken = default);
		public Task<IEnumerable<TEntity>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default);
		public Task<TEntity> Create(TEntity entity, CancellationToken canecllationToken = default);
		public Task<TEntity> Update(Guid id, TEntity entity, CancellationToken canecllationToken = default);
		public Task<TEntity> Delete(Guid id, CancellationToken canecllationToken = default);
	}
}
