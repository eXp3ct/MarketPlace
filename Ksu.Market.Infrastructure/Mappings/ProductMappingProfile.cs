﻿using AutoMapper;
using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;

namespace Ksu.Market.Infrastructure.Mappings
{
	public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<IProductCreated, Product>()
				.ForMember(p => p.Id,
					opt => opt.MapFrom(x => Guid.NewGuid()))
				.ForMember(p => p.DatePublished,
					opt => opt.MapFrom(x => DateTime.UtcNow))
				.ForMember(p => p.Rating,
					opt => opt.MapFrom(x => 0));

			CreateMap<UpdateProductDto, Product>()
				.ForMember(p => p.DateChanged,
					opt => opt.MapFrom(x => DateTime.UtcNow))
				.ForMember(p => p.Rating,
					opt => opt.Ignore());
		}
	}
}