using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.UpdateProduct
{
	public class UpdateProductConsumingQuery : IRequest<IOperationResult>
	{
		public IUpdateProductRequired UpdateProductRequired { get; set; }

		public UpdateProductConsumingQuery(IUpdateProductRequired updateProductRequired)
		{
			UpdateProductRequired = updateProductRequired;
		}
	}
}