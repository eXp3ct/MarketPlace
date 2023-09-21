using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteProduct
{
	public class DeleteProductProducingQuery : IRequest<IOperationResult>
	{
		public Guid Id { get; set; }

		public DeleteProductProducingQuery(Guid id)
		{
			Id = id;
		}
	}
}