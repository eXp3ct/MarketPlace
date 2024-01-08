using Ksu.Market.Domain.Interfaces;

namespace Ksu.Market.Domain.Models
{
	public class Product : IHaveId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public float Rating { get; set; }
		public List<Category>? Categories { get; set; }
		public List<Feature>? Features { get; set; }
		public DateTime DatePublished { get; set; }
		public DateTime? DateChanged { get; set; }
		public virtual List<ProductImage> Images { get; set; }
	}
}