using MediatR;
using Microsoft.AspNetCore.Mvc;

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
	}
}
