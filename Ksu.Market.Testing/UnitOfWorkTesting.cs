using Ksu.Market.Api;
using Ksu.Market.Data.Contexts;
using Ksu.Market.Data.Repositories;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Enums;
using Ksu.Market.Domain.Models;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Testing
{
	public class UnitOfWorkTesting
	{
		private readonly TestServer _server;

        public UnitOfWorkTesting()
        {
			_server = new TestServer(Program.CreateHostBuilder(Array.Empty<string>()).Build().Services);
		}

		[Fact]
		public async Task AddProductToUnitOfWork_NotNull()
		{
			var context = new AppDbContext();
			var repo = new ProductRepository(context);
			var logs = new OperationResultRepository(context);
			var unit = new UnitOfWork(context, repo, logs);

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

			await unit.ProductRepository.Create(product);
			await unit.SaveChangesAsync();

			var existingProduct = await unit.ProductRepository.GetByIdAsync(pId);

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
			var logs = new OperationResultRepository(context);
			var unit = new UnitOfWork(context, repo, logs);

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

			await unit.ProductRepository.Create(product);
			await unit.SaveChangesAsync();

			var existingProduct = await unit.ProductRepository.Delete(pId);
			await unit.SaveChangesAsync();
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
		public async Task UpdateProduct_NotNull()
		{
			var context = new AppDbContext();
			var repo = new ProductRepository(context);
			var logs = new OperationResultRepository(context);
			var unit = new UnitOfWork(context, repo, logs);

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

			await unit.ProductRepository.Create(product);
			await unit.SaveChangesAsync();

			var productToUpdate = new Product
			{
				Id = pId,
				Name = "UPDATEDTEST",
				Description = "UPDATEDTEST",
				Price = 123456,
				Rating = 2,
				DateChanged = DateTime.UtcNow,
				DatePublished = DateTime.UtcNow,
				Features = new List<Feature>
				{
					new Feature
					{
						Id = Guid.NewGuid(),
						Name = "UPDATEDTEST",
						Value = "UPDATEDTEST"
					},
					new Feature
					{
						Id = Guid.NewGuid(),
						Name = "UPDATEDTEST",
						Value = "UPDATEDTEST"
					}
				},
				Categories = new List<Category>
				{
					new Category { Id = Guid.NewGuid(), Name = "UPDATEDTEST", AgeRestriction = AgeRestriction.Teens},
					new Category { Id = Guid.NewGuid(), Name = "UPDATEDTEST", AgeRestriction = AgeRestriction.Adults}
				}
			};

			var updated = await unit.ProductRepository.Update(pId, productToUpdate);
			await unit.SaveChangesAsync();

			var updatedProduct = await unit.ProductRepository.GetByIdAsync(updated.Id);

			Assert.NotNull(updatedProduct);
			Assert.Equal(productToUpdate.Name, updatedProduct.Name);
			Assert.Equal(productToUpdate.Description, updatedProduct.Description);
			Assert.Equal(productToUpdate.Price, updatedProduct.Price);
			Assert.Equal(productToUpdate.Rating, updatedProduct.Rating);
		}
    }
}
