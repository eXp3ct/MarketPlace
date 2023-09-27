using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Infrastructure.Commands.Consuming.GetReview;
using MassTransit;
using MediatR;

namespace Ksu.Market.Reviews.Consumers
{
	public class GetReviewRequiredConsumer : IConsumer<IGetReviewRequired>
	{
		private readonly IMediator _mediator;

		public GetReviewRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IGetReviewRequired> context)
		{
			var query = new GetReviewConsumingQuery(context.Message);

			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}
