using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure.Commands.Producing.AddProduct;
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
		/// <returns>Созданный продукт</returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IOperationResult))]
		public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto)
		{
			var result = await _mediator.Send(new AddProductProducingQuery(dto));

			return Created($"/{result.Id}", result);
		}
	}
}
