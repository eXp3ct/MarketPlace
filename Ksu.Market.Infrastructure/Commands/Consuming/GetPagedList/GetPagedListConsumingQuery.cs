using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetPagedList
{
	public class GetPagedListConsumingQuery : IRequest<IOperationResult>
	{
		public IGetProductPagedListRequired Query { get; set; }

		public GetPagedListConsumingQuery(IGetProductPagedListRequired query)
		{
			Query = query;
		}
	}
}