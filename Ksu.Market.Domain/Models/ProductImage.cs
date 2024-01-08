using Ksu.Market.Domain.Interfaces;

namespace Ksu.Market.Domain.Models
{
    public class ProductImage : IHaveId
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ExtensionName { get; set; }
        public DateTime DateUploaded { get; set; }
        public string FilePath { get; set; }
        public Guid ProductId { get; set; }
    }
}
