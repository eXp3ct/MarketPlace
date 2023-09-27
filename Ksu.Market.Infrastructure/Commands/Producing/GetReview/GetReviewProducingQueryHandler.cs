using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetReview
{
	public class GetReviewProducingQueryHandler : IRequestHandler<GetReviewProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public GetReviewProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(GetReviewProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IGetReviewRequired, IOperationResult>(request, cancellationToken);

			return result.Message;
		}
	}
}
