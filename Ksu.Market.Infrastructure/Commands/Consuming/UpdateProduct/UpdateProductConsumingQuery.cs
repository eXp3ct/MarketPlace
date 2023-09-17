using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
