using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

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

			var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(request.UpdateProductRequired.Id, cancellationToken);
			product.Rating = existingProduct.Rating;

			var updated = await _unitOfWork.ProductRepository.Update(request.UpdateProductRequired.Id, product, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
			return new OperationResult(updated, true);
		}
	}
}