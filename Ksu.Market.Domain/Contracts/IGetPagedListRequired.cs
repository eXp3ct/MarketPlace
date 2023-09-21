namespace Ksu.Market.Domain.Contracts
{
	public interface IGetPagedListRequired
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}