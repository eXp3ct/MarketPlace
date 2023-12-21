using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetReview
{
	public class GetReviewConsumingQueryHandler : IRequestHandler<GetReviewConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Review> _repository;

		public GetReviewConsumingQueryHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(GetReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var review = await _repository.GetByIdAsync(request.GetReview.Id, cancellationToken);

			return new OperationResult(review, true);
		}
	}
}
