using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetReviewPagedList
{
	public class GetReviewPagedListConsumingQueryHandler : IRequestHandler<GetReviewPagedListConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _unitOfWork;

		public GetReviewPagedListConsumingQueryHandler(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IOperationResult> Handle(GetReviewPagedListConsumingQuery request, CancellationToken cancellationToken)
		{
			var list = await (await _unitOfWork.ReviewRepository
				.GetListAsync(request.GetReviewPaged.Page, request.GetReviewPaged.PageSize, cancellationToken))
				.ToListAsync(cancellationToken);

			return new OperationResult(list, true);
		}
	}
}
