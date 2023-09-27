using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.UpdateReview
{
	public class UpdateReviewProducingQueryHandler : IRequestHandler<UpdateReviewProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public UpdateReviewProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(UpdateReviewProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IUpdateReviewRequired, IOperationResult>(new
			{
				Id = request.Id,
				UpdateReviewDto = request.Dto
			}, cancellationToken);

			return result.Message;
		}
	}
}
