using Ksu.Market.Domain.Dtos;

namespace Ksu.Market.Domain.Contracts.Reviews
{
	public interface IUpdateReviewRequired
	{
		public Guid Id { get; set; }
		public UpdateReviewDto UpdateReviewDto { get; set; }
	}
}
