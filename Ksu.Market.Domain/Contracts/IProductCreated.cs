using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Contracts
{
	public interface IProductCreated
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public List<CategoryDto>? Categories { get; set; }
		public List<FeatureDto>? Features { get; set; }
	}	
}
