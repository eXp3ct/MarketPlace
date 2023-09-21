using FluentValidation;
using Ksu.Market.Infrastructure.Commands.Producing.AddReview;
using Ksu.Market.Infrastructure.Validation.DtoValidation;

namespace Ksu.Market.Infrastructure.Validation.QueryValidation
{
	public class AddReviewQueryValidator : AbstractValidator<AddReviewProducingQuery>
	{
		public AddReviewQueryValidator()
		{
			RuleFor(x => x.ReviewDto).SetValidator(new ReviewDtoValidator());
		}
	}
}