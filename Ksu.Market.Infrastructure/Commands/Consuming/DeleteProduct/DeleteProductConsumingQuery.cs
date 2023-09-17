using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
