using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Infrastructure.Commands.Consuming.AddProduct
{
	public class AddProductConsumingQueryHandler : IRequestHandler<AddProductConsumingQuery, IOperationResult>
	{
		private readonly IMapper _mapper;
		private readonly UnitOfWork _unitOfWork;
		private readonly ILogger<AddProductConsumingQueryHandler> _logger;

		public AddProductConsumingQueryHandler(IMapper mapper, UnitOfWork unitOfWork, ILogger<AddProductConsumingQueryHandler> logger)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<IOperationResult> Handle(AddProductConsumingQuery request, CancellationToken cancellationToken)
		{
			var product = _mapper.Map<Product>(request.ProductDto);

			var entry = await _unitOfWork.ProductRepository.Create(product, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			_logger.LogInformation($"Product {entry.Id} added to database");

			return new OperationResult(entry, true);
		}
	}
}