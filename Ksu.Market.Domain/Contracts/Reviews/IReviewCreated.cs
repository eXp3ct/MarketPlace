namespace Ksu.Market.Domain.Contracts.Reviews
{
	public interface IReviewCreated
	{
		public string Author { get; set; }
		public string Header { get; set; }
		public string? Content { get; set; }
		public float Rating { get; set; }
		public Guid ProductId { get; set; }
	}
}