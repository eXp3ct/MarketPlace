using AutoMapper;
using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MediatR;

namespace Ksu.Market.Infrastructure.Commands.Consuming.UpdateReview
{
	public class UpdateReviewConsumingQueryHandler : IRequestHandler<UpdateReviewConsumingQuery, IOperationResult>
	{
		private readonly IRepository<Review> _reviewRepository;
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public UpdateReviewConsumingQueryHandler(IRepository<Review> reviewRepository, IProductRepository repository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IOperationResult> Handle(UpdateReviewConsumingQuery request, CancellationToken cancellationToken)
		{
			var oldReview = await _reviewRepository.GetByIdAsync(request.UpdateReview.Id, cancellationToken);
			var newReview = _mapper.Map(request.UpdateReview.UpdateReviewDto, oldReview);
			newReview.Author = oldReview.Author;
			newReview.ProductId = oldReview.ProductId;


			// Получаем все отзывы для данного продукта
			var reviewsForProduct = (await _reviewRepository
				.GetListAsync(1, 1000, cancellationToken)).Where(x => x.ProductId == newReview.ProductId).ToList();

			// Пересчитываем средний рейтинг для продукта
			var averageRating = default(float);
			if (reviewsForProduct.Any())
			{
				averageRating = reviewsForProduct.Average(r => r.Rating);
			}
			else
			{
				averageRating = newReview.Rating;
			}
			// Обновляем рейтинг продукта
			//var product = await _repository.GetByIdAsync(newReview.ProductId, cancellationToken);
			//product.Rating = averageRating;

			// Обновляем продукт и список отзывов
			await _repository.UpdateRating(newReview.Id, averageRating, cancellationToken);

			await _repository.SaveChangesAsync(cancellationToken);
			await _reviewRepository.SaveChangesAsync(cancellationToken);

			return new OperationResult(newReview, true);
		}
	}
}
