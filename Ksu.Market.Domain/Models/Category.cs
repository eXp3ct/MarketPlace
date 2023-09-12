using Ksu.Market.Domain.Enums;
using Ksu.Market.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Models
{
	public class Category : IHaveId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public AgeRestriction AgeRestriction { get; set; }
	}
}
