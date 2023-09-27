using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.DeleteReview
{
	public class DeleteReviewConsumingQuery : IRequest<IOperationResult>
	{
		public IDeleteReviewRequired DeleteReview { get; set; }

		public DeleteReviewConsumingQuery(IDeleteReviewRequired deleteReview)
		{
			DeleteReview = deleteReview;
		}
	}
}
