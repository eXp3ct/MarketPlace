using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Infrastructure.Behavior
{
	public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

		public LoggingBehavior(UnitOfWork unitOfWork, ILogger<LoggingBehavior<TRequest, TResponse>> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var result = await next();

			if (result is not OperationResult)
				return result;

			await _unitOfWork.OperationResultRepository.Create(result as OperationResult, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			_logger.LogInformation($"Operation result {(result as OperationResult).Id} saved to database");
			return (TResponse)(object)result;
		}
	}
}