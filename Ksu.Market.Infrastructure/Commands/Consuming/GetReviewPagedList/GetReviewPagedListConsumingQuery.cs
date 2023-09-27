using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetReviewPagedList
{
	public class GetReviewPagedListConsumingQuery : IRequest<IOperationResult>
	{
		public IGetReviewPagedListRequired GetReviewPaged { get; set; }

		public GetReviewPagedListConsumingQuery(IGetReviewPagedListRequired getReviewPaged)
		{
			GetReviewPaged = getReviewPaged;
		}
	}
}
