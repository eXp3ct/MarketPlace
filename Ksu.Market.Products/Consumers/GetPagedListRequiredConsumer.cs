using Ksu.Market.Domain.Contracts;
using Ksu.Market.Infrastructure.Commands.Consuming.GetPagedList;
using MassTransit;
using MediatR;

namespace Ksu.Market.Products.Consumers
{
	public class GetPagedListRequiredConsumer : IConsumer<IGetProductPagedListRequired>
	{
		private readonly IMediator _mediator;

		public GetPagedListRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IGetProductPagedListRequired> context)
		{
			var query = new GetPagedListConsumingQuery(context.Message);

			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}