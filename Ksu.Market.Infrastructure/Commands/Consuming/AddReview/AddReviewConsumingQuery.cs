using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.AddReview
{
	public class AddReviewConsumingQuery : IRequest<IOperationResult>
	{
		public IReviewCreated ReviewCreated { get; set; }

		public AddReviewConsumingQuery(IReviewCreated reviewCreated)
		{
			ReviewCreated = reviewCreated;
		}
	}
}
