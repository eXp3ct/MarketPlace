using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.GetPagedList
{
	public class GetPagedListConsumingQueryHandler : IRequestHandler<GetPagedListConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetPagedListConsumingQueryHandler(UnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IOperationResult> Handle(GetPagedListConsumingQuery request, CancellationToken cancellationToken)
		{
			var products = await _unitOfWork.ProductRepository.GetListAsync(request.Query.Page, request.Query.PageSize, cancellationToken);

			return new OperationResult(products, true);
		}
	}
}
