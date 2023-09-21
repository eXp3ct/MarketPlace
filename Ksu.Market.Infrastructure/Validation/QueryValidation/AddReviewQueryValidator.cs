using FluentValidation;
using Ksu.Market.Infrastructure.Commands.Producing.AddReview;
using Ksu.Market.Infrastructure.Validation.DtoValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
