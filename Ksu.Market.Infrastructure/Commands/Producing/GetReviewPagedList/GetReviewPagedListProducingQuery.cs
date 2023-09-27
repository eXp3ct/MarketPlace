using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetReviewPagedList
{
	public class GetReviewPagedListProducingQuery : IRequest<IOperationResult>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }

		public GetReviewPagedListProducingQuery(int page, int pageSize)
		{
			Page = page;
			PageSize = pageSize;
		}
	}
}
