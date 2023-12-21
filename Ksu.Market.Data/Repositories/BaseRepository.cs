using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Data.Repositories
{
	public class BaseRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IHaveId
	{
		private readonly IAppDbContext _context;
		private readonly DbSet<TEntity> _set;
		private readonly ILogger<BaseRepository<TEntity>> _logger;

		public BaseRepository(IAppDbContext context, ILogger<BaseRepository<TEntity>> logger)
		{
			_set = context.Set<TEntity>();
			_logger = logger;
			_context = context;
		}

		public async Task<TEntity> Create(TEntity entity, CancellationToken canecllationToken = default)
		{
			var entry = await _set.AddAsync(entity, canecllationToken)
				?? throw new ArgumentNullException($"Failed to create {typeof(TEntity).Name} in database");

			_logger.LogInformation("Created {Name} in database", typeof(TEntity).Name);

			return entry.Entity;
		}

		public async Task<TEntity> Delete(Guid id, CancellationToken canecllationToken = default)
		{
			var entry = _set.Remove(await GetByIdAsync(id, canecllationToken));

			_logger.LogInformation("Deleted {Name} from database", typeof(TEntity).Name);

			return entry.Entity;
		}

		public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken canecllationToken = default)
		{
			var entry = await _set
				.FirstOrDefaultAsync(x => x.Id == id, canecllationToken)
				?? throw new ArgumentNullException($"Failed to find entity {typeof(TEntity).Name} in database, doesn't exists");

			_logger.LogInformation("Get {Name} by id {id} from database", typeof(TEntity).Name, id);

			return entry;
		}

		public async Task<IEnumerable<TEntity>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default)
		{
			var list = await _set
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync(canecllationToken)
				?? throw new ArgumentNullException($"Failed to get paged list: p-{page}, s-{pageSize} of type {typeof(TEntity).Name}");

			_logger.LogInformation("Get paged list p-{page}, s-{pageSize} of type {Name} from database", page, pageSize, typeof(TEntity).Name);

			return list;
		}
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}


		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}		
	}
}
