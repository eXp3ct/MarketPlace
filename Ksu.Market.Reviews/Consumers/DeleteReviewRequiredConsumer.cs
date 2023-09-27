using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Infrastructure.Commands.Consuming.DeleteReview;
using MassTransit;
using MediatR;

namespace Ksu.Market.Reviews.Consumers
{
	public class DeleteReviewRequiredConsumer : IConsumer<IDeleteReviewRequired>
	{
		private readonly IMediator _mediator;

		public DeleteReviewRequiredConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IDeleteReviewRequired> context)
		{
			var query = new DeleteReviewConsumingQuery(context.Message);

			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}
