using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Data.Repositories
{
	public class ReviewRepository : IRepository<Review>
	{
		private readonly IAppDbContext _context;
		private readonly ILogger<ReviewRepository> _logger;

		public ReviewRepository(IAppDbContext context, ILogger<ReviewRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public ReviewRepository(IAppDbContext context)
		{
			_context = context;
		}

		public async Task<Review> Create(Review entity, CancellationToken canecllationToken = default)
		{
			var entry = await _context.Reviews.AddAsync(entity, canecllationToken)
				?? throw new ArgumentException();

			return entry.Entity;
		}

		public async Task<Review> Delete(Guid id, CancellationToken canecllationToken = default)
		{
			var review = await GetByIdAsync(id, canecllationToken);

			var entry = _context.Reviews.Remove(review)
				?? throw new ArgumentException();

			return entry.Entity;
		}

		public async Task<Review> GetByIdAsync(Guid id, CancellationToken canecllationToken = default)
		{
			var entity = await _context.Reviews
											.FirstOrDefaultAsync(p => p.Id == id, canecllationToken)
											?? throw new ArgumentException();
			return entity;
		}

		public async Task<IEnumerable<Review>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default)
		{
			var list = await _context.Reviews
										.Skip((page - 1) * pageSize)
										.Take(pageSize)
										.ToListAsync(canecllationToken);
			return list;
		}

		public async Task<Review> Update(Guid id, Review entity, CancellationToken canecllationToken = default)
		{
			var deleted = await Delete(id, canecllationToken);

			entity.DateCreated = deleted.DateCreated;
			entity.Id = id;
			var review = await Create(entity, canecllationToken);

			return review;
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