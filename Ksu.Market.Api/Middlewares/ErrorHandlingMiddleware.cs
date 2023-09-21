using FluentValidation;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using System.Net;

namespace Ksu.Market.Api.Middlewares
{
	/// <summary>
	/// Обработчик ошибок
	/// </summary>
	public class ErrorHandlingMiddleware : IMiddleware
	{
		private readonly UnitOfWork _unitOfWork;

		/// <summary>
		/// Внедрение зависимостей
		/// </summary>
		/// <param name="unitOfWork"></param>
		public ErrorHandlingMiddleware(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
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

				await _unitOfWork.OperationResultRepository.Create(result);
				await _unitOfWork.SaveChangesAsync();

				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

				await context.Response.WriteAsJsonAsync(result);
			}
		}
	}
}