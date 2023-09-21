using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Producing.AddProduct;
using Ksu.Market.Infrastructure.Commands.Producing.DeleteProduct;
using Ksu.Market.Infrastructure.Commands.Producing.DeleteProducts;
using Ksu.Market.Infrastructure.Commands.Producing.GetPagedList;
using Ksu.Market.Infrastructure.Commands.Producing.GetProduct;
using Ksu.Market.Infrastructure.Commands.Producing.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ksu.Market.Api.Controllers
{
	/// <summary>
	/// Контроллер продуктов
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly ILogger<ProductsController> _logger;
		private readonly IMediator _mediator;

		/// <summary>
		/// Внедрение зависимостей
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="mediator"></param>
		public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Создание продукта в базе данных
		/// </summary>
		/// <param name="dto">Информация о продукте</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Созданный продукт</returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new AddProductProducingQuery(dto), cancellationToken);

			if (result.IsSuccess)
			{
				return Created($"/{result.Id}", result);
			}

			return BadRequest(result);
		}

		/// <summary>
		/// Получение списка продуктов
		/// </summary>
		/// <param name="page">Номер страницы</param>
		/// <param name="pageSize">Размер страницы</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Список продуктов</returns>
		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> GetPagedList(int page, int pageSize, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetPagedListProducingQuery(page, pageSize), cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		/// <summary>
		/// Получение продукта
		/// </summary>
		/// <param name="id">Id продукта</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Продукт</returns>
		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetProductByIdProducingQuery(id), cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}

		/// <summary>
		/// Обновление продукта
		/// </summary>
		/// <param name="id">Id продукта</param>
		/// <param name="dto">Информация о продукте</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Обновленный продукт</returns>
		[HttpPut]
		[Route("{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto dto, CancellationToken cancellationToken)
		{
			var query = new UpdateProductProducingQuery(id, dto);
			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		/// <summary>
		/// Удаление продукта из базы данных
		/// </summary>
		/// <param name="id">Id продукта</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Удаленный продукт</returns>
		[HttpDelete]
		[Route("{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
		{
			var query = new DeleteProductProducingQuery(id);
			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}

		/// <summary>
		/// Удаление продуктов из базы данных
		/// </summary>
		/// <param name="ids">Id продуктов</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><see cref="IOperationResult"/>Удаленные продукты</returns>
		[HttpDelete]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IOperationResult))]
		[ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IOperationResult))]
		[ProducesErrorResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> DeleteProducts([FromBody] IEnumerable<Guid> ids, CancellationToken cancellationToken)
		{
			var query = new DeleteProductsQuery(ids);
			var result = await _mediator.Send(query, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}
	}
}