using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetProduct
{
	public class GetProductByIdProducingQueryHandler : IRequestHandler<GetProductByIdProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public GetProductByIdProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(GetProductByIdProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IGetProductRequired, IOperationResult>(new
			{
				request.Id
			}, cancellationToken);

			return result.Message;
		}
	}
}
