using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetReviewPagedList
{
	public class GetReviewPagedListProducingQueryHandler : IRequestHandler<GetReviewPagedListProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public GetReviewPagedListProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(GetReviewPagedListProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IGetReviewPagedListRequired, IOperationResult>(request, cancellationToken);

			return result.Message;
		}
	}
}
