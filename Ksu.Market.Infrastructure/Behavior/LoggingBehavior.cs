using Ksu.Market.Domain.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ksu.Market.Infrastructure.Behavior
{
	public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

		public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
		{
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var result = await next();

			if (result is not OperationResult)
				return result;

			_logger.LogInformation("Operation result {result}", result);


			return (TResponse)(object)result;
		}
	}
}