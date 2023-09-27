using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.DeleteReview
{
	public class DeleteReviewConsumingQueryHandler : IRequestHandler<DeleteReviewConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _unitOfWork;

		public DeleteReviewConsumingQueryHandler(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IOperationResult> Handle(DeleteReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var review = await _unitOfWork.ReviewRepository.Delete(request.DeleteReview.Id, cancellationToken);

			return new OperationResult(review, true);
		}
	}
}
