using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Infrastructure.Commands.Consuming.UpdateReview;
using MassTransit;
using MediatR;

namespace Ksu.Market.Reviews.Consumers
{
	public class UpdateReviewRequiredConsumer : IConsumer<IUpdateReviewRequired>
	{
		private readonly IMediator _mediator;

		public UpdateReviewRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IUpdateReviewRequired> context)
		{
			var query = new UpdateReviewConsumingQuery(context.Message);

			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}
