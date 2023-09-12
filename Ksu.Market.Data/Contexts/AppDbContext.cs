using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Data.Contexts
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public DbSet<Product> Products { get; set; }
		private readonly IConfiguration _configuration;

		public AppDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var conntextionString = _configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseNpgsql(conntextionString);
		}
	}
}
