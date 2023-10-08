using Ksu.Market.Api;
using Ksu.Market.Data.Contexts;
using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Ksu.Market.Products.Consumers;
using Ksu.Market.Testing.Fixtures;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Testing
{
	public class ProductTests : IClassFixture<IntegrationTestFactory<Program, AppDbContext>>
	{
		private readonly IntegrationTestFactory<Program, AppDbContext> _factory;

		public ProductTests(IntegrationTestFactory<Program, AppDbContext> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task Get_ListProducts_Success()
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync("/api/products?page=1&pageSize=10");

			response.EnsureSuccessStatusCode();
        }
	}
}
