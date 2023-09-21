using Ksu.Market.Domain.Contracts;
using Ksu.Market.Infrastructure.Commands.Consuming.UpdateProduct;
using MassTransit;
using MediatR;

namespace Ksu.Market.Products.Consumers
{
	public class UpdateProductRequiredConsumer : IConsumer<IUpdateProductRequired>
	{
		private readonly IMediator _mediator;

		public UpdateProductRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IUpdateProductRequired> context)
		{
			var query = new UpdateProductConsumingQuery(context.Message);
			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}