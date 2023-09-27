using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Producing.UpdateReview
{
	public class UpdateReviewProducingQuery : IRequest<IOperationResult>
	{
		public Guid Id { get; set; }
		public UpdateReviewDto Dto { get; set; }

		public UpdateReviewProducingQuery(Guid id, UpdateReviewDto dto)
		{
			this.Id = id;
			Dto = dto;
		}
	}
}
