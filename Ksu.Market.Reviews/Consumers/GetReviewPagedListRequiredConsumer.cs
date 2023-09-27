using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Infrastructure.Commands.Consuming.GetReviewPagedList;
using MassTransit;
using MediatR;

namespace Ksu.Market.Reviews.Consumers
{
	public class GetReviewPagedListRequiredConsumer : IConsumer<IGetReviewPagedListRequired>
	{
		private readonly IMediator _mediator;

		public GetReviewPagedListRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IGetReviewPagedListRequired> context)
		{
			var query = new GetReviewPagedListConsumingQuery(context.Message);

			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}
