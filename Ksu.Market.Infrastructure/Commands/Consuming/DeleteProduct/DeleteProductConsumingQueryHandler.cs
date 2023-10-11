using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.DeleteProduct
{
	public class DeleteProductConsumingQueryHandler : IRequestHandler<DeleteProductConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Product> _repository;

		public DeleteProductConsumingQueryHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(DeleteProductConsumingQuery request, CancellationToken cancellationToken)
		{
			var deleted = await _repository.Delete(request.DeleteProductRequired.Id, cancellationToken);

			await _repository.SaveChangesAsync(cancellationToken);

			return new OperationResult(deleted, true);
		}
	}
}