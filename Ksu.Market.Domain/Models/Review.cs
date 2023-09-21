using Ksu.Market.Domain.Interfaces;

namespace Ksu.Market.Domain.Models
{
	public class Review : IHaveId
	{
		public Guid Id { get; set; }
		public string Author { get; set; }
		public string Header { get; set; }
		public string? Content { get; set; }
		public float Rating { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateChanged { get; set; }
		public Guid ProductId { get; set; }
	}
}
