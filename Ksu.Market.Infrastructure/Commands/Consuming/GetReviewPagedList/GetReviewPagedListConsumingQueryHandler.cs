using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetReviewPagedList
{
	public class GetReviewPagedListConsumingQueryHandler : IRequestHandler<GetReviewPagedListConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Review> _repository;

		public GetReviewPagedListConsumingQueryHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(GetReviewPagedListConsumingQuery request, CancellationToken cancellationToken)
		{
			var list = await _repository.GetListAsync(request.GetReviewPaged.Page, request.GetReviewPaged.PageSize, cancellationToken);

			return new OperationResult(list, true);
		}
	}
}
