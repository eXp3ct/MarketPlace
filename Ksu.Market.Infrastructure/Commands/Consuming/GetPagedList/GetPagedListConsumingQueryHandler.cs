using AutoMapper;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetPagedList
{
	public class GetPagedListConsumingQueryHandler : IRequestHandler<GetPagedListConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Product> _repository;

		public GetPagedListConsumingQueryHandler(IRepository<Product> repository)
		{
			_repository = repository;
		}

		public async Task<IOperationResult> Handle(GetPagedListConsumingQuery request, CancellationToken cancellationToken)
		{
			var products = await _repository.GetListAsync(request.Query.Page, request.Query.PageSize, cancellationToken);

			return new OperationResult(products, true);
		}
	}
}