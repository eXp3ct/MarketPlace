using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetReview
{
	public class GetReviewProducingQuery : IRequest<IOperationResult>
	{
		public Guid Id { get; set; }

		public GetReviewProducingQuery(Guid id)
		{
			Id = id;
		}
	}
}
