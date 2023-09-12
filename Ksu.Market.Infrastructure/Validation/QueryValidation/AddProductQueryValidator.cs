using FluentValidation;
using Ksu.Market.Infrastructure.Commands.Producing.AddProduct;
using Ksu.Market.Infrastructure.Validation.DtoValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
