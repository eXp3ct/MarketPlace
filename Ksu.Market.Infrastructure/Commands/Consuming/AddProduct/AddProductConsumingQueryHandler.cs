using AutoMapper;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Infrastructure.Commands.Consuming.AddProduct
{
	public class AddProductConsumingQueryHandler : IRequestHandler<AddProductConsumingQuery, IOperationResult>
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Product> _repository;
		private readonly ILogger<AddProductConsumingQueryHandler> _logger;

		public AddProductConsumingQueryHandler(IMapper mapper, IRepository<Product> repository, ILogger<AddProductConsumingQueryHandler> logger)
		{
			_mapper = mapper;
			_repository = repository;
			_logger = logger;
		}

		public async Task<IOperationResult> Handle(AddProductConsumingQuery request, CancellationToken cancellationToken)
		{
			var product = _mapper.Map<Product>(request.ProductDto);

			var entry = await _repository.Create(product, cancellationToken);
			await _repository.SaveChangesAsync(cancellationToken);

			_logger.LogInformation("Product {id} added to database", entry.Id);

			return new OperationResult(entry, true);
		}
	}
}