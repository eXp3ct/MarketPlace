namespace Ksu.Market.Domain.Contracts.Reviews
{
	public interface IGetReviewPagedListRequired
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
