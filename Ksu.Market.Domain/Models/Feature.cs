using Ksu.Market.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Models
{
	public class Feature : IHaveId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}
}
