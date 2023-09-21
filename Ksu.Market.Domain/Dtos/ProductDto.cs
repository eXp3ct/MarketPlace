using Ksu.Market.Domain.Contracts;

namespace Ksu.Market.Domain.Dtos
{
	public class ProductDto : IProductCreated
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public List<CategoryDto>? Categories { get; set; }
		public List<FeatureDto>? Features { get; set; }
	}
}