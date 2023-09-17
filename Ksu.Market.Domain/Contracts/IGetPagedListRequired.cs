using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Contracts
{
	public interface IGetPagedListRequired
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
