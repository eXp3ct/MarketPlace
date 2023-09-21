using Ksu.Market.Domain.Enums;
using Ksu.Market.Domain.Interfaces;

namespace Ksu.Market.Domain.Models
{
	public class Category : IHaveId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public AgeRestriction AgeRestriction { get; set; }
	}
}