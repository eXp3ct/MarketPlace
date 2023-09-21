using AutoMapper;
using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Models;

namespace Ksu.Market.Infrastructure.Mappings
{
	public class ReviewMappingProfile : Profile
	{
		public ReviewMappingProfile()
		{
			CreateMap<IReviewCreated, Review>()
				.ForMember(x => x.Id,
					opt => opt.MapFrom(x => Guid.NewGuid()))
				.ForMember(x => x.DateCreated,
					opt => opt.MapFrom(x => DateTime.UtcNow));
		}
	}
}