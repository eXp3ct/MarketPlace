using Ksu.Market.Domain.Contracts.Reviews;

namespace Ksu.Market.Domain.Dtos
{
	public class ReviewDto : IReviewCreated
	{
		public string Author { get; set; }
		public string Header { get; set; }
		public string? Content { get; set; }
		public float Rating { get; set; }
		public Guid ProductId { get; set; }
	}
}