using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetReview
{
	public class GetReviewConsumingQuery : IRequest<IOperationResult>
	{
		public IGetReviewRequired GetReview { get; set; }

		public GetReviewConsumingQuery(IGetReviewRequired getReview)
		{
			GetReview = getReview;
		}
	}
}
