using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

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
			var result = await _bus.Request<IGetProductPagedListRequired, IOperationResult>(new
			{
				Page = request.Page,
				PageSize = request.PageSize,
			}, cancellationToken);

			return result.Message;
		}
	}
}