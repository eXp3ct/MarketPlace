using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteProducts
{
	public class DeleteProductsQuery : IRequest<IOperationResult>
	{
		public IEnumerable<Guid> Ids { get; set; }

		public DeleteProductsQuery(IEnumerable<Guid> ids)
		{
			Ids = ids;
		}
	}
}
