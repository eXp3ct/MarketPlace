using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.UpdateProduct
{
	public class UpdateProductProducingQueryHandler : IRequestHandler<UpdateProductProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public UpdateProductProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(UpdateProductProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IUpdateProductRequired, IOperationResult>(new
			{
				Id = request.Id,
				ProductDto = request.UpdateProductDto
			}, cancellationToken);

			return result.Message;
		}
	}
}