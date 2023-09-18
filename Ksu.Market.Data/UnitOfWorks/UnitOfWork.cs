using Ksu.Market.Data.Interfaces;
using Ksu.Market.Data.Repositories;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Data.UnitOfWorks
{
	public class UnitOfWork : IDisposable
	{
		private readonly IAppDbContext _context;
		private IRepository<Product> _productRepository;
		private IRepository<OperationResult> _operationResultRepository;
		private IRepository<Review> _reviewRepository;
		public IRepository<Product> ProductRepository
		{
			get
			{
				_productRepository ??= new ProductRepository(_context);

				return _productRepository;
			}
		}
		public IRepository<OperationResult> OperationResultRepository
		{
			get
			{
				_operationResultRepository ??= new OperationResultRepository(_context);

				return _operationResultRepository;
			}
		}

		public IRepository<Review> ReviewRepository
		{
			get
			{
				_reviewRepository ??= new ReviewRepository(_context);

				return _reviewRepository;
			}
		}

		public UnitOfWork(IAppDbContext context, 
			IRepository<Product> productRepository, 
			IRepository<OperationResult> operationResultRepository, 
			IRepository<Review> reviewRepository)
		{
			_context = context;
			_productRepository = productRepository;
			_operationResultRepository = operationResultRepository;
			_reviewRepository = reviewRepository;
		}

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return _context.SaveChangesAsync(cancellationToken);
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
					_productRepository.Dispose();
					_operationResultRepository.Dispose();
					_reviewRepository.Dispose();
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
