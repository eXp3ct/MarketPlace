using AutoMapper;
using Ksu.Market.Data.UnitOfWorks;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.AddReview
{
	public class AddReviewConsumingQueryHandler : IRequestHandler<AddReviewConsumingQuery, IOperationResult>
	{
		private readonly IMapper _mapper;
		private readonly UnitOfWork _unitOfWork;

		public AddReviewConsumingQueryHandler(IMapper mapper, UnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IOperationResult> Handle(AddReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var review = _mapper.Map<Review>(request.ReviewCreated);

			// Получаем все отзывы для данного продукта
			var reviewsForProduct = (await _unitOfWork.ReviewRepository
				.GetListAsync(1, 1000, cancellationToken)).Where(x => x.ProductId == review.ProductId).ToList();


			// Пересчитываем средний рейтинг для продукта
			var averageRating = default(float);
			if(reviewsForProduct.Any())
			{
				averageRating = reviewsForProduct.Average(r => r.Rating);
			}
			else
			{
				averageRating = review.Rating;
			}
			// Обновляем рейтинг продукта
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(review.ProductId, cancellationToken);
			product.Rating = averageRating;

			// Обновляем продукт и список отзывов
			await _unitOfWork.ProductRepository.UpdateRating(product.Id, averageRating, cancellationToken);
			await _unitOfWork.ReviewRepository.Create(review, cancellationToken);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return new OperationResult(review, true);
		}
	}
}
