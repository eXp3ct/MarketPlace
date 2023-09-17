using AutoMapper;
using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    opt => opt.MapFrom(x => DateTime.UtcNow));

            CreateMap<UpdateProductDto, Product>()
                .ForMember(p => p.DateChanged, 
                    opt => opt.MapFrom(x => DateTime.UtcNow));
        }
    }
}
