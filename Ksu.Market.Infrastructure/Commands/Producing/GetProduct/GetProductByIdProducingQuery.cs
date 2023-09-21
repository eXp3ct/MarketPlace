using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetProduct
{
	public class GetProductByIdProducingQuery : IRequest<IOperationResult>
	{
		public Guid Id { get; set; }

		public GetProductByIdProducingQuery(Guid id)
		{
			Id = id;
		}
	}
}