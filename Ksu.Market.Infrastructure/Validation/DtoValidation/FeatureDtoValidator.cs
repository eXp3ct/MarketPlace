using FluentValidation;
using Ksu.Market.Domain.Dtos;

namespace Ksu.Market.Infrastructure.Validation.DtoValidation
{
	public class FeatureDtoValidator : AbstractValidator<FeatureDto>
	{
		public FeatureDtoValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(1).MaximumLength(64);
			RuleFor(x => x.Value).NotNull().NotEmpty().MinimumLength(1).MaximumLength(64);
		}
	}
}