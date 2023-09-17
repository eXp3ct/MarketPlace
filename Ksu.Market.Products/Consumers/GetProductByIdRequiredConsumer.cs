using Ksu.Market.Domain.Contracts;
using Ksu.Market.Infrastructure.Commands.Consuming.GetProduct;
using MassTransit;
using MediatR;

namespace Ksu.Market.Products.Consumers
{
	public class GetProductByIdRequiredConsumer : IConsumer<IGetProductRequired>
	{
		private readonly IMediator _mediator;

		public GetProductByIdRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IGetProductRequired> context)
		{
			var query = new GetProductByIdConsumingQuery(context.Message);
			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}
