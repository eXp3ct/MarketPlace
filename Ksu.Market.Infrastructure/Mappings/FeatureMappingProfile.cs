using AutoMapper;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;

namespace Ksu.Market.Infrastructure.Mappings
{
	public class FeatureMappingProfile : Profile
	{
		public FeatureMappingProfile()
		{
			CreateMap<FeatureDto, Feature>()
				.ForMember(f => f.Id,
					opt => opt.MapFrom(dto => Guid.NewGuid()));
		}
	}
}