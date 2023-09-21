using AutoMapper;
using Ksu.Market.Domain.Contracts.Reviews;
using Ksu.Market.Domain.Dtos;
using Ksu.Market.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
