using Ksu.Market.Domain.Contracts;
using Ksu.Market.Infrastructure.Commands.Consuming.DeleteProduct;
using MassTransit;
using MediatR;

namespace Ksu.Market.Products.Consumers
{
	public class DeleteProductRequiredConsumer : IConsumer<IDeleteProductRequired>
	{
		private readonly IMediator _mediator;

		public DeleteProductRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IDeleteProductRequired> context)
		{
			var query = new DeleteProductConsumingQuery(context.Message);
			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}