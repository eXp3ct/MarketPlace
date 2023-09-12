using FluentValidation;
using Ksu.Market.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Validation.DtoValidation
{
	public class CategoryDtoValidator : AbstractValidator<CategoryDto>
	{
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(128);
            RuleFor(x => x.AgeRestriction).NotNull().NotEmpty().IsInEnum();
        }
    }
}
