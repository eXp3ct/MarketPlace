using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Consuming.AddProduct;
using MassTransit;
using MediatR;

namespace Ksu.Market.Products.Consumers
{
	public class ProductCreatedConsumer : IConsumer<IProductCreated>
	{
		private readonly IMediator _mediator;

		public ProductCreatedConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IProductCreated> context)
		{
			var query = new AddProductConsumingQuery(context.Message);
			var result = await _mediator.Send(query);
			await context.RespondAsync(result);
		}
	}
}
