namespace Ksu.Market.Domain.Dtos
{
	public class UpdateReviewDto
	{
		public string Header { get; set; }
		public string? Content { get; set; }
		public float Rating { get; set; }
	}
}
