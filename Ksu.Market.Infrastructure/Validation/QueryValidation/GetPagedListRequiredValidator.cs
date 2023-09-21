using FluentValidation;
using Ksu.Market.Infrastructure.Commands.Producing.GetPagedList;

namespace Ksu.Market.Infrastructure.Validation.QueryValidation
{
	public class GetPagedListRequiredValidator : AbstractValidator<GetPagedListProducingQuery>
	{
		public GetPagedListRequiredValidator()
		{
			RuleFor(x => x.Page).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
			RuleFor(x => x.PageSize).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
		}
	}
}