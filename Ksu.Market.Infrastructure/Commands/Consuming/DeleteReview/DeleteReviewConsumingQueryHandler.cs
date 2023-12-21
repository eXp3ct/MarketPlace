using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.DeleteReview
{
	public class DeleteReviewConsumingQueryHandler : IRequestHandler<DeleteReviewConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Review> _repository;

		public DeleteReviewConsumingQueryHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(DeleteReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var review = await _repository.Delete(request.DeleteReview.Id, cancellationToken);

			await _repository.SaveChangesAsync(cancellationToken);

			return new OperationResult(review, true);
		}
	}
}
