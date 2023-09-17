using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetProduct
{
	public class GetProductByIdConsumingQueryHandler : IRequestHandler<GetProductByIdConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _unitOfWork;

		public GetProductByIdConsumingQueryHandler(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IOperationResult> Handle(GetProductByIdConsumingQuery request, CancellationToken cancellationToken)
		{
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.GetProductRequired.Id, cancellationToken);

			return new OperationResult(product, true);
		}
	}
}
