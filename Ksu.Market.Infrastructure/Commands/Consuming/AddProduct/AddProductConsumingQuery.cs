using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.AddProduct
{
	public class AddProductConsumingQuery : IRequest<IOperationResult>
	{
		public IProductCreated ProductDto { get; set; }

		public AddProductConsumingQuery(IProductCreated productDto)
		{
			ProductDto = productDto;
		}
	}
}