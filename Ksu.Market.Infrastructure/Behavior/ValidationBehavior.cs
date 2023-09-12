using FluentValidation;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Behavior
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);
			var failures = _validators
								.Select(v => v.Validate(context))
								.SelectMany(v => v.Errors)
								.Where(failure => failure != null)
								.ToList();

			if(failures.Any())
			{
				return Task.FromResult((TResponse)(object)new OperationResult(failures.Select(x => new
				{
					x.ErrorMessage,
					x.AttemptedValue,
				}), false));
			}

			return next();
		}
	}
}
