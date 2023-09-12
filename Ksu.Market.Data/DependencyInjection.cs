using Ksu.Market.Data.Contexts;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Data.Repositories;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Data
{
	public static class DependencyInjection
	{
		public static void AddPersistance(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>();
			services.AddScoped<IAppDbContext, AppDbContext>();
			services.AddScoped<IRepository<Product>, ProductRepository>();
			services.AddScoped<IRepository<OperationResult>, OperationResultRepository>();
			services.AddScoped<UnitOfWork>();
		}
	}
}
