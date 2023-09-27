using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.UpdateReview
{
	public class UpdateReviewConsumingQuery : IRequest<IOperationResult>
	{
		public IUpdateReviewRequired UpdateReview { get; set; }

		public UpdateReviewConsumingQuery(IUpdateReviewRequired updateReview)
		{
			UpdateReview = updateReview;
		}
	}
}
