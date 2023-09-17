using Ksu.Market.Data.Contexts;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Data.Repositories
{
	public class ProductRepository : IRepository<Product>
	{
		private readonly IAppDbContext _context;

		public ProductRepository(IAppDbContext context)
		{
			_context = context;
		}

		public async Task<Product> Create(Product entity, CancellationToken canecllationToken = default)
		{
			var entry = await _context.Products.AddAsync(entity, canecllationToken) 
				?? throw new ArgumentException("Exception occured while adding entity to database");

			return entry.Entity;
		}

		public async Task<Product> Delete(Guid id, CancellationToken canecllationToken = default)
		{
			var product = await GetByIdAsync(id, canecllationToken);

			var entry = _context.Products.Remove(product)
				?? throw new ArgumentException("Exception occured while deleting entity from database");

			return entry.Entity;
		}
		public async Task<Product> GetByIdAsync(Guid id, CancellationToken canecllationToken = default)
		{
			var entity = await _context.Products
				.Include(x => x.Categories)
				.Include(x => x.Features)
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: canecllationToken)
				?? throw new ArgumentException("Exception occured while finding entity from database");

			return entity;
		}

		public async Task<IEnumerable<Product>> GetListAsync(int page, int pageSize, CancellationToken canecllationToken = default)
		{
			var list = await _context.Products
											.Include(x => x.Categories)
											.Include(x => x.Features)
											.Skip((page - 1) * pageSize)
											.Take(pageSize)
											.ToListAsync(canecllationToken)
										?? throw new ArgumentException("Exception occured while getting list from database");

			return list;
		}

		public async Task<Product> Update(Guid id, Product entity, CancellationToken canecllationToken = default)
		{
			var deleted = await Delete(id, canecllationToken);

			//TODO: Костыль, убрать от сюда
			entity.DatePublished = deleted.DatePublished;

			var product = await Create(entity, canecllationToken);

			return product;
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
