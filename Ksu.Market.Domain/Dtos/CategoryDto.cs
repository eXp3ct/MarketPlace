using Ksu.Market.Domain.Enums;

namespace Ksu.Market.Domain.Dtos
{
	public class CategoryDto
	{
		public string Name { get; set; }
		public AgeRestriction AgeRestriction { get; set; }
	}
}