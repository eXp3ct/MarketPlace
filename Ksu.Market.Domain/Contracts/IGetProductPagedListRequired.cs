namespace Ksu.Market.Domain.Contracts
{
	public interface IGetProductPagedListRequired
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}