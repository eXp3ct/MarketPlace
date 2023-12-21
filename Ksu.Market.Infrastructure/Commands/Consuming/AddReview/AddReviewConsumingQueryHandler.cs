using AutoMapper;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.AddReview
{
	public class AddReviewConsumingQueryHandler : IRequestHandler<AddReviewConsumingQuery, IOperationResult>
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Review> _reviewRepository;
		private readonly IProductRepository _productRepository;

		public AddReviewConsumingQueryHandler(IMapper mapper, IRepository<Review> repository, IProductRepository productRepository)
		{
			_mapper = mapper;
			_reviewRepository = repository;
			_productRepository = productRepository;
		}

		public async Task<IOperationResult> Handle(AddReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var review = _mapper.Map<Review>(request.ReviewCreated);

			// Получаем все отзывы для данного продукта
			var reviewsForProduct = (await _reviewRepository
				.GetListAsync(1, 1000, cancellationToken)).Where(x => x.ProductId == review.ProductId).ToList();

			// Пересчитываем средний рейтинг для продукта
			var averageRating = default(float);
			if (reviewsForProduct.Any())
			{
				averageRating = reviewsForProduct.Average(r => r.Rating);
			}
			else
			{
				averageRating = review.Rating;
			}
			// Обновляем рейтинг продукта
			var product = await _reviewRepository.GetByIdAsync(review.ProductId, cancellationToken);
			product.Rating = averageRating;

			// Обновляем продукт и список отзывов
			await _productRepository.UpdateRating(product.Id, averageRating, cancellationToken);
			await _reviewRepository.Create(review, cancellationToken);

			await _productRepository.SaveChangesAsync(cancellationToken);
			await _reviewRepository.SaveChangesAsync(cancellationToken);

			return new OperationResult(review, true);
		}
	}
}