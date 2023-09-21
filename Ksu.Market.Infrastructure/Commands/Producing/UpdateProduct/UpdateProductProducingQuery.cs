using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.UpdateProduct
{
	public class UpdateProductProducingQuery : IRequest<IOperationResult>
	{
		public Guid Id { get; set; }
		public UpdateProductDto UpdateProductDto { get; set; }

		public UpdateProductProducingQuery(Guid id, UpdateProductDto updateProductDto)
		{
			Id = id;
			UpdateProductDto = updateProductDto;
		}
	}
}