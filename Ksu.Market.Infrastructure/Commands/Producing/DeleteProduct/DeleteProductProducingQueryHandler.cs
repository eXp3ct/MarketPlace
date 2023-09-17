using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MassTransit;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteProduct
{
	public class DeleteProductProducingQueryHandler : IRequestHandler<DeleteProductProducingQuery, IOperationResult>
	{
		private readonly IBus _bus;

		public DeleteProductProducingQueryHandler(IBus bus)
		{
			_bus = bus;
		}

		public async Task<IOperationResult> Handle(DeleteProductProducingQuery request, CancellationToken cancellationToken)
		{
			var result = await _bus.Request<IDeleteProductRequired, IOperationResult>(new
			{
				Id = request.Id,
			}, cancellationToken);

			return result.Message;
		}
	}
}
