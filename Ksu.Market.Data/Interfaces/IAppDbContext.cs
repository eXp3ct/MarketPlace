using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Data.Interfaces
{
	public interface IAppDbContext : IDisposable
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<OperationResult> OperationResults { get; set; }
		public DbSet<Review> Reviews { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
