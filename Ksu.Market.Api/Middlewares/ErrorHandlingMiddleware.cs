using FluentValidation;
using Ksu.Market.Domain.Results;
using MassTransit;
using System.Net;

namespace Ksu.Market.Api.Middlewares
{
	/// <summary>
	/// Обработчик ошибок
	/// </summary>
	public class ErrorHandlingMiddleware : IMiddleware
	{
		private readonly ILogger<ErrorHandlingMiddleware> _logger;

		/// <summary>
		/// Внедрение зависимостей
		/// </summary>
		/// <param name="logger"></param>
		public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Обработка ошибок
		/// </summary>
		/// <param name="context"></param>
		/// <param name="next"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (ValidationException ex)
			{
				var errors = ex.Errors
									.Select(e => new
									{
										e.ErrorMessage,
										e.AttemptedValue
									})
									.ToList();

				var result = new OperationResult(errors, false);

				await LogToFile(context, result, ex);
			}
			catch (ArgumentException ex)
			{
				var error = ex.Message;

				var result = new OperationResult(error, false);

				await LogToFile(context, result, ex);
			}
			catch (MassTransitException ex)
			{
				var error = ex.Message;

				var result = new OperationResult(error, false);

				await LogToFile(context, result, ex);
			}
		}

		private async Task LogToFile(HttpContext context, OperationResult result, Exception exception)
		{
			_logger.LogError(exception, "Operation result is: {result}", result);

			context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

			await context.Response.WriteAsJsonAsync(result);
		}
	}
}