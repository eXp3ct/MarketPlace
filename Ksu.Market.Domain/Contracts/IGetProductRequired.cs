using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Contracts
{
	public interface IGetProductRequired
	{
		public Guid Id { get; set; }
	}
}
