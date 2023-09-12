using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Interfaces
{
	public interface IHaveId
	{
		public Guid Id { get; set; }
	}
}
