using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetPagedList
{
	public class GetPagedListProducingQuery : IRequest<IOperationResult>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }

		public GetPagedListProducingQuery(int page, int pageSize)
		{
			Page = page;
			PageSize = pageSize;
		}
	}
}