using Ksu.Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Data.Interfaces
{
	public interface IAppDbContext
	{
		public DbSet<Product> Products { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
