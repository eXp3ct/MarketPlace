using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.GetPagedList
{
	public class GetPagedListProducingQuery : IRequest<IOperationResult>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }

		public GetPagedListProducingQuery(int page, int pageSize)
		{
			Page = page;
			PageSize = pageSize;
		}
	}
}
