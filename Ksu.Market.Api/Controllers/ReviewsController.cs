using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Producing.AddReview;
using Ksu.Market.Infrastructure.Commands.Producing.DeleteReview;
using Ksu.Market.Infrastructure.Commands.Producing.GetReview;
using Ksu.Market.Infrastructure.Commands.Producing.GetReviewPagedList;
using Ksu.Market.Infrastructure.Commands.Producing.UpdateReview;
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
		/// <returns><see cref="IOperationResult"/> Созданный ревью</returns>
		[HttpPost]
		[Produces("application/json")]
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

		/// <summary>
		/// Получение списка ревью
		/// </summary>
		/// <param name="page">Номер страницы</param>
		/// <param name="pageSize">Размер страницы</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/> Лист ревью</returns>
		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> GetReviewList(int page, int pageSize, CancellationToken cancellationToken)
		{
			var query = new GetReviewPagedListProducingQuery(page, pageSize);

			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		/// <summary>
		/// Получение ревью 
		/// </summary>
		/// <param name="id">Id ревью</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/> Ревью</returns>
		[HttpGet]
		[Route("{id}")]
		[Produces("application/json")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> GetReviewById([FromRoute] Guid id, CancellationToken cancellationToken)
		{
			var query = new GetReviewProducingQuery(id);

			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}

		/// <summary>
		/// Удаление ревью из базы данных
		/// </summary>
		/// <param name="id">Id ревью</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/> Удаленный ревью</returns>
		[HttpDelete]
		[Route("{id}")]
		[Produces("application/json")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> DeleteReviewById([FromRoute] Guid id, CancellationToken cancellationToken)
		{
			var query = new DeleteReviewProducingQuery(id);

			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}

		/// <summary>
		/// Обновление ревью в базе данных
		/// </summary>
		/// <param name="id">Id ревью</param>
		/// <param name="dto">Новая информация о ревью</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/> Обновленный ревью</returns>
		[HttpPut]
		[Route("{id}")]
		[Produces("application/json")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> UpdateReview([FromRoute] Guid id, [FromBody] UpdateReviewDto dto, CancellationToken cancellationToken)
		{
			var query = new UpdateReviewProducingQuery(id, dto);

			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}
	}
}