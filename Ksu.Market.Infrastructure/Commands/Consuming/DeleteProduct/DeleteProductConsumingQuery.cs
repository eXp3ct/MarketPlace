using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.DeleteProduct
{
	public class DeleteProductConsumingQuery : IRequest<IOperationResult>
	{
		public IDeleteProductRequired DeleteProductRequired { get; set; }

		public DeleteProductConsumingQuery(IDeleteProductRequired deleteProductRequired)
		{
			DeleteProductRequired = deleteProductRequired;
		}
	}
}