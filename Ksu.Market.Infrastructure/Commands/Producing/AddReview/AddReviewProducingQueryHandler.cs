using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.AddReview
{
	public class AddReviewProducingQueryHandler : IRequestHandler<AddReviewProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public AddReviewProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(AddReviewProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IReviewCreated, IOperationResult>(request.ReviewDto, cancellationToken);

			return result.Message;
		}
	}
}
