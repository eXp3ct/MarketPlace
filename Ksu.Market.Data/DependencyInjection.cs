using Ksu.Market.Data.Contexts;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Data.Repositories;
using Ksu.Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ksu.Market.Data
{
	public static class DependencyInjection
	{
		public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});
			services.AddScoped<IAppDbContext, AppDbContext>();

			services.AddScoped<IRepository<Review>, BaseRepository<Review>>();
			services.AddScoped<IRepository<Product>, ProductRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
		}
	}
}