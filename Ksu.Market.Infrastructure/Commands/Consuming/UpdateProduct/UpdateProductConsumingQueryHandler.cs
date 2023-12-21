using AutoMapper;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.UpdateProduct
{
	public class UpdateProductConsumingQueryHandler : IRequestHandler<UpdateProductConsumingQuery, IOperationResult>
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Product> _repository;

		public UpdateProductConsumingQueryHandler(IMapper mapper, IRepository<Product> repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(UpdateProductConsumingQuery request, CancellationToken cancellationToken)
		{
			var existingProduct = await _repository.GetByIdAsync(request.UpdateProductRequired.Id, cancellationToken);
			var product = _mapper.Map(request.UpdateProductRequired.ProductDto, existingProduct);

			product.Rating = existingProduct.Rating;

			await _repository.SaveChangesAsync(cancellationToken);
			return new OperationResult(product, true);
		}
	}
}