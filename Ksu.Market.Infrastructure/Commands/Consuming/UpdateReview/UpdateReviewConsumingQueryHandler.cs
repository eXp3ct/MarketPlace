using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Infrastructure.Commands.Consuming.UpdateReview
{
	public class UpdateReviewConsumingQueryHandler : IRequestHandler<UpdateReviewConsumingQuery, IOperationResult>
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateReviewConsumingQueryHandler(UnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IOperationResult> Handle(UpdateReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var newReview = _mapper.Map<Review>(request.UpdateReview.UpdateReviewDto);
			var oldReview = await _unitOfWork.ReviewRepository.GetByIdAsync(request.UpdateReview.Id, cancellationToken);
			newReview.Author = oldReview.Author;
			newReview.ProductId = oldReview.ProductId;

			var updated = await _unitOfWork.ReviewRepository.Update(request.UpdateReview.Id, newReview, cancellationToken);

			// Получаем все отзывы для данного продукта
			var reviewsForProduct = (await _unitOfWork.ReviewRepository
				.GetListAsync(1, 1000, cancellationToken)).Where(x => x.ProductId == updated.ProductId).ToList();

			// Пересчитываем средний рейтинг для продукта
			var averageRating = default(float);
			if (reviewsForProduct.Any())
			{
				averageRating = reviewsForProduct.Average(r => r.Rating);
			}
			else
			{
				averageRating = updated.Rating;
			}
			// Обновляем рейтинг продукта
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(updated.ProductId, cancellationToken);
			product.Rating = averageRating;

			// Обновляем продукт и список отзывов
			await _unitOfWork.ProductRepository.UpdateRating(product.Id, averageRating, cancellationToken);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return new OperationResult(updated, true);
		}
	}
}
