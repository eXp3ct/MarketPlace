using Ksu.Market.Domain.Interfaces;

namespace Ksu.Market.Domain.Models
{
	public class Feature : IHaveId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}
}