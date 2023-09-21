using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Producing.AddReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ksu.Market.Api.Controllers
{
	/// <summary>
	/// Контроллер отзывов
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		/// <summary>
		/// Внедрение зависимостей
		/// </summary>
		/// <param name="mediator"></param>
		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Создание ревью в базе данных
		/// </summary>
		/// <param name="reviewDto">Информация о ревью</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Созданный ревью</returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto, CancellationToken cancellationToken)
		{
			var query = new AddReviewProducingQuery(reviewDto);

			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Created($"/{result.Id}", result);
			}

			return BadRequest(result);
		}
	}
}