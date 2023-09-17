﻿using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.DeleteProduct
{
	public class DeleteProductConsumingQueryHandler : IRequestHandler<DeleteProductConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _unitOfWork;

		public DeleteProductConsumingQueryHandler(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IOperationResult> Handle(DeleteProductConsumingQuery request, CancellationToken cancellationToken)
		{
			var deleted = await _unitOfWork.ProductRepository.Delete(request.DeleteProductRequired.Id, cancellationToken);

			return new OperationResult(deleted, true);
		}
	}
}
