using AutoMapper;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;

namespace Ksu.Market.Infrastructure.Mappings
{
	public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile()
		{
			CreateMap<CategoryDto, Category>()
				.ForMember(c => c.Id,
					opt => opt.MapFrom(dto => Guid.NewGuid()));
		}
	}
}