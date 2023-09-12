using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.AddProduct
{
	public class AddProductProducingQueryHandler : IRequestHandler<AddProductProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public AddProductProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(AddProductProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IProductCreated, IOperationResult>(request.ProductDto);

			return result.Message;
		}
	}
}
