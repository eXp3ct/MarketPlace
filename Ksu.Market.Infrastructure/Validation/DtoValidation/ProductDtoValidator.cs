using FluentValidation;
using Ksu.Market.Domain.Dtos;

namespace Ksu.Market.Infrastructure.Validation.DtoValidation
{
	public class ProductDtoValidator : AbstractValidator<ProductDto>
	{
		public ProductDtoValidator()
		{
			RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(256);
			RuleFor(x => x.Description).MaximumLength(256);
			RuleFor(x => x.Categories).NotNull().NotEmpty().ForEach(x => x.SetValidator(new CategoryDtoValidator()));
			RuleFor(x => x.Features).NotEmpty().NotNull().ForEach(x => x.SetValidator(new FeatureDtoValidator()));
			RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(0);
		}
	}
}