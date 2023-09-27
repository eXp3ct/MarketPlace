using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteReview
{
	public class DeleteReviewProducingQueryHandler : IRequestHandler<DeleteReviewProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public DeleteReviewProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(DeleteReviewProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IDeleteReviewRequired, IOperationResult>(request, cancellationToken);

			return result.Message;
		}
	}
}
