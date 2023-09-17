using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetPagedList
{
	public class GetPagedListProducingQueryHandler : IRequestHandler<GetPagedListProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public GetPagedListProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(GetPagedListProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IGetPagedListRequired, IOperationResult>(new
			{
				Page = request.Page,
				PageSize = request.PageSize,
			}, cancellationToken);

			return result.Message;
		}
	}
}
