using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetReview
{
	public class GetReviewConsumingQueryHandler : IRequestHandler<GetReviewConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _uniOfWork;

		public GetReviewConsumingQueryHandler(UnitOfWork uniOfWork)
		{
			_uniOfWork = uniOfWork;
		}

		public async Task<IOperationResult> Handle(GetReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var review = await _uniOfWork.ReviewRepository.GetByIdAsync(request.GetReview.Id, cancellationToken);

			return new OperationResult(review, true);
		}
	}
}
