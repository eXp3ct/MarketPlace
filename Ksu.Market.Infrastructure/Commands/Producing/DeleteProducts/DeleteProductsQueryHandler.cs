using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Producing.DeleteProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Producing.DeleteProducts
{
	public class DeleteProductsQueryHandler : IRequestHandler<DeleteProductsQuery, IOperationResult>
	{
		private readonly IMediator _mediator;

		public DeleteProductsQueryHandler(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IOperationResult> Handle(DeleteProductsQuery request, CancellationToken cancellationToken)
		{
			var deletedList = new List<object>();

			foreach(var id in request.Ids)
			{
				var query = new DeleteProductProducingQuery(id);
				var result = await _mediator.Send(query, cancellationToken);

				deletedList.Add(result.Data);
			}

			return new OperationResult(deletedList, true);
		}
	}
}
