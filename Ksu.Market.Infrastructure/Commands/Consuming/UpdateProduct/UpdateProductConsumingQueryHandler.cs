using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.UpdateProduct
{
	public class UpdateProductConsumingQueryHandler : IRequestHandler<UpdateProductConsumingQuery, IOperationResult>
	{
		private readonly IMapper _mapper;
		private readonly UnitOfWork _unitOfWork;

		public UpdateProductConsumingQueryHandler(IMapper mapper, UnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IOperationResult> Handle(UpdateProductConsumingQuery request, CancellationToken cancellationToken)
		{
			var product = _mapper.Map<Product>(request.UpdateProductRequired.ProductDto);
			product.Id = request.UpdateProductRequired.Id;
			
			var updated = await _unitOfWork.ProductRepository.Update(request.UpdateProductRequired.Id, product, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
			return new OperationResult(updated, true);
		}
	}
}
