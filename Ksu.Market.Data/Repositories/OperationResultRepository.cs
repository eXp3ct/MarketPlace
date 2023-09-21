using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Results;
using Microsoft.EntityFrameworkCore;

namespace Ksu.Market.Data.Repositories
{
	public class OperationResultRepository : IRepository<OperationResult>
	{
		private readonly IAppDbContext _context;

		public OperationResultRepository(IAppDbContext context)
		{
			_context = context;
		}

		public async Task<OperationResult> Create(OperationResult entity, CancellationToken canecllationToken = default)
		{
			var entry = await _context.OperationResults.AddAsync(entity, canecllationToken)
				?? throw new ArgumentException("Exception occured while adding entity to database");

			return entry.Entity;
		}

		public async Task<OperationResult> Delete(Guid id, CancellationToken canecllationToken = default)
		{
			var entity = await _context.OperationResults.FindAsync(new object?[] { id }, canecllationToken)
				?? throw new ArgumentException("Exception occured while finding entity for deleting in database");

			var entry = _context.OperationResults.Remove(entity)
				?? throw new ArgumentException("Exception occured while deleting entity from database");

			return entry.Entity;
		}

		public async Task<OperationResult> GetByIdAsync(Guid id, CancellationToken canecllationToken = default)
		{
			var entity = await _context.OperationResults.FindAsync(new object?[] { id }, canecllationToken)
				?? throw new ArgumentException("Exception occured while finding entity in database");

			return entity;
		}

		public async Task<IEnumerable<OperationResult>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default)
		{
			var list = await _context.OperationResults
												.Skip((page - 1) * pageSize)
												.Take(pageSize)
												.ToListAsync(canecllationToken);

			return list;
		}

		public async Task<OperationResult> Update(Guid id, OperationResult entity, CancellationToken canecllationToken = default)
		{
			var result = await _context.OperationResults.FindAsync(new object?[] { id }, canecllationToken)
				?? throw new ArgumentException("Exception occured while finding entity to update database");

			result = entity;

			return result;
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