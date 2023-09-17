using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetPagedList
{
	public class GetPagedListConsumingQuery : IRequest<IOperationResult>
	{
		public IGetPagedListRequired Query { get; set; }

		public GetPagedListConsumingQuery(IGetPagedListRequired query)
		{
			Query = query;
		}
	}
}
