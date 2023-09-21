using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.AddReview
{
	public class AddReviewProducingQuery : IRequest<IOperationResult>
	{
		public ReviewDto ReviewDto { get; set; }

		public AddReviewProducingQuery(ReviewDto reviewDto)
		{
			ReviewDto = reviewDto;
		}
	}
}