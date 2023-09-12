using Ksu.Market.Api;
using Ksu.Market.Data.Contexts;
using Ksu.Market.Domain.Enums;
using Ksu.Market.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ksu.Market.Testing
{
	public class DbTesting
	{
		private readonly TestServer _server;

        public DbTesting()
        {
			_server = new TestServer(Program.CreateHostBuilder(Array.Empty<string>()).Build().Services);
			
        }

        [Fact]
		public void AddEntityToDb_NotNull()
		{
			//Arrange
			var context = new AppDbContext(_server.Services.GetRequiredService<IConfiguration>());
			var pId = Guid.NewGuid();
			var fId = Guid.NewGuid();
			var fId1 = Guid.NewGuid();
			var cId = Guid.NewGuid();
			var cId1 = Guid.NewGuid();
			var product = new Product
			{
				Id = pId,
				Name = "TestProduct",
				Description = "TestDescription",
				Price = 123,
				Rating = 4.5f,
				DateChanged = DateTime.UtcNow,
				DatePublished = DateTime.UtcNow,
				Features = new List<Feature>
				{
					new Feature
					{
						Id = fId,
						Name = "Weight",
						Value = "325kg"
					},
					new Feature
					{
						Id = fId1,
						Name = "Size",
						Value = "2x2x2"
					}
				},
				Categories = new List<Category>
				{
					new Category { Id = cId, Name = "Home", AgeRestriction = AgeRestriction.Teens},
					new Category { Id = cId1, Name = "Tech", AgeRestriction = AgeRestriction.Adults}
				}
			};

			//Act
			context.Products.Add(product);
			context.SaveChanges();

			//Assert
			var existingProduct = context.Products.Find(pId);

			Assert.NotNull(existingProduct);
			Assert.NotNull(existingProduct.Features);
			Assert.NotNull(existingProduct.Categories);

			Assert.Equal(pId, existingProduct.Id);
			Assert.Equal(fId, existingProduct.Features.First().Id);
			Assert.Equal(fId1, existingProduct.Features.Last().Id);
			Assert.Equal(cId, existingProduct.Categories.First().Id);
			Assert.Equal(cId1, existingProduct.Categories.Last().Id);
		}
	}
}