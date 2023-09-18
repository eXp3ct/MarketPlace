using Ksu.Market.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Models
{
	public class Review : IHaveId
	{
		public Guid Id { get; set; }
		public string Author { get; set; }
		public string Header { get; set; }
		public string? Content { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateChanged { get; set; }
		public Product Product { get; set; }
	}
}
