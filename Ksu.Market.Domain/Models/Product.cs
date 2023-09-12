using Ksu.Market.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public DateTime DateChanged { get; set; }
	}
}
