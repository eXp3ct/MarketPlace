using Ksu.Market.Domain.Dtos;

namespace Ksu.Market.Domain.Contracts
{
	public interface IUpdateProductRequired
	{
		public Guid Id { get; set; }
		public UpdateProductDto ProductDto { get; set; }
	}
}