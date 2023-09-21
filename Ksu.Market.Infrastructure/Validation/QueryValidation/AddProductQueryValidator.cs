using FluentValidation;
using Ksu.Market.Infrastructure.Commands.Producing.AddProduct;
using Ksu.Market.Infrastructure.Validation.DtoValidation;

namespace Ksu.Market.Infrastructure.Validation.QueryValidation
{
	public class AddProductQueryValidator : AbstractValidator<AddProductProducingQuery>
	{
		public AddProductQueryValidator()
		{
			RuleFor(x => x.ProductDto).SetValidator(new ProductDtoValidator());
		}
	}
}