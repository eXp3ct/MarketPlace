using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
