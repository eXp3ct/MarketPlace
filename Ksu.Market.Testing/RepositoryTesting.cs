using Ksu.Market.Api;
using Ksu.Market.Data.Contexts;
using Ksu.Market.Data.Repositories;
using Ksu.Market.Domain.Enums;
using Ksu.Market.Domain.Models;
using Microsoft.AspNetCore.TestHost;

namespace Ksu.Market.Testing
{
	public class RepositoryTesting
	{
		private readonly TestServer _server;

		public RepositoryTesting()
		{
			_server = new TestServer(Program.CreateHostBuilder(Array.Empty<string>()).Build().Services);
		}

		[Fact]
		public async Task AddProductToRepository_NotNull()
		{
			var context = new AppDbContext();
			var repo = new ProductRepository(context);

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

			await repo.Create(product);
			await context.SaveChangesAsync();

			var existingProduct = await repo.GetByIdAsync(pId);

			Assert.NotNull(existingProduct);
			Assert.NotNull(existingProduct.Features);
			Assert.NotNull(existingProduct.Categories);

			Assert.Equal(pId, existingProduct.Id);
			Assert.Equal(fId, existingProduct.Features.First().Id);
			Assert.Equal(fId1, existingProduct.Features.Last().Id);
			Assert.Equal(cId, existingProduct.Categories.First().Id);
			Assert.Equal(cId1, existingProduct.Categories.Last().Id);
		}

		[Fact]
		public async Task DeleteProduct_NotNull()
		{
			var context = new AppDbContext();
			var repo = new ProductRepository(context);

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

			await repo.Create(product);
			await context.SaveChangesAsync();

			var deleted = await repo.Delete(pId);
			await context.SaveChangesAsync();

			Assert.NotNull(deleted);
			Assert.NotNull(deleted.Features);
			Assert.NotNull(deleted.Categories);

			Assert.Equal(pId, deleted.Id);
			Assert.Equal(fId, deleted.Features.First().Id);
			Assert.Equal(fId1, deleted.Features.Last().Id);
			Assert.Equal(cId, deleted.Categories.First().Id);
			Assert.Equal(cId1, deleted.Categories.Last().Id);
		}
	}
}