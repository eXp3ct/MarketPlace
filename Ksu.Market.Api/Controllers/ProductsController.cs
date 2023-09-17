using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Producing.AddProduct;
using Ksu.Market.Infrastructure.Commands.Producing.GetPagedList;
using MassTransit;
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
		/// <returns>Созданный продукт</returns>
		[HttpPost]
		[ProducesDefaultResponseType(typeof(IOperationResult))]
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
		/// <returns></returns>
		[HttpGet]
		[ProducesDefaultResponseType(typeof(IOperationResult))]
		public async Task<IActionResult> GetPagedList(int page, int pageSize, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetPagedListProducingQuery(page, pageSize), cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}
	}
}
