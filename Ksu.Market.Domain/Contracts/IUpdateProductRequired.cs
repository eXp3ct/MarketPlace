using Ksu.Market.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Contracts
{
	public interface IUpdateProductRequired
	{
		public Guid Id { get; set; }
		public UpdateProductDto ProductDto { get; set; }
	}
}
