using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Infrastructure.Commands.Consuming.AddReview;
using MassTransit;
using MediatR;

namespace Ksu.Market.Reviews.Consumers
{
	public class ReviewCreatedConsumer : IConsumer<IReviewCreated>
	{
		private readonly IMediator _mediator;

		public ReviewCreatedConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IReviewCreated> context)
		{
			var query = new AddReviewConsumingQuery(context.Message);

			var result = await _mediator.Send(query, context.CancellationToken);

			await context.RespondAsync(result);
		}
	}
}