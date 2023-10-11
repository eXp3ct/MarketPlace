using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetProduct
{
	public class GetProductByIdConsumingQueryHandler : IRequestHandler<GetProductByIdConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Product> _repository;

		public GetProductByIdConsumingQueryHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(GetProductByIdConsumingQuery request, CancellationToken cancellationToken)
		{
			var product = await _repository.GetByIdAsync(request.GetProductRequired.Id, cancellationToken);

			return new OperationResult(product, true);
		}
	}
}