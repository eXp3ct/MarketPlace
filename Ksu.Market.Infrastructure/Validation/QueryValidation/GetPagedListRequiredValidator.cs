using FluentValidation;
using Ksu.Market.Infrastructure.Commands.Producing.GetPagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
