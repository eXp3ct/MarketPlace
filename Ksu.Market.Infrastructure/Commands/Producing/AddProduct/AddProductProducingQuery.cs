using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.AddProduct
{
	public class AddProductProducingQuery : IRequest<IOperationResult>
	{
		public ProductDto ProductDto { get; set; }

		public AddProductProducingQuery(ProductDto productDto)
		{
			ProductDto = productDto;
		}
	}
}
