using FluentValidation;
using Ksu.Market.Domain.Dtos;

namespace Ksu.Market.Infrastructure.Validation.DtoValidation
{
	public class ReviewDtoValidator : AbstractValidator<ReviewDto>
	{
		public ReviewDtoValidator()
		{
			RuleFor(x => x.Author).NotEmpty().NotNull();
			RuleFor(x => x.Header).NotEmpty().NotNull();
			RuleFor(x => x.Rating).NotEmpty().NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(5);
		}
	}
}