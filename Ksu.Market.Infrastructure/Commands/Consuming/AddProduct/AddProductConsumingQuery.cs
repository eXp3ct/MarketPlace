using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
