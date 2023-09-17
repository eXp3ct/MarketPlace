using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetProduct
{
	public class GetProductByIdConsumingQuery : IRequest<IOperationResult>
	{
		public IGetProductRequired GetProductRequired { get; set; }

		public GetProductByIdConsumingQuery(IGetProductRequired getProductRequired)
		{
			GetProductRequired = getProductRequired;
		}
	}
}
