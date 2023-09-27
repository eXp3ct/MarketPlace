using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteReview
{
	public class DeleteReviewProducingQuery : IRequest<IOperationResult>
	{
		public Guid id { get; set; }

		public DeleteReviewProducingQuery(Guid id)
		{
			this.id = id;
		}
	}
}
