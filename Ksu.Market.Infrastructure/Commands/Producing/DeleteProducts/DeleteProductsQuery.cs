using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteProducts
{
	public class DeleteProductsQuery : IRequest<IOperationResult>
	{
		public IEnumerable<Guid> Ids { get; set; }

		public DeleteProductsQuery(IEnumerable<Guid> ids)
		{
			Ids = ids;
		}
	}
}