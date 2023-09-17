using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteProduct
{
	public class DeleteProductProducingQuery : IRequest<IOperationResult>
	{
		public Guid Id { get; set; }

		public DeleteProductProducingQuery(Guid id)
		{
			Id = id;
		}
	}
}
