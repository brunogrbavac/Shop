using Application.Common.Dtos;
using AutoMapper;
using Domain.Entites;
using System.Collections.Generic;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));

            CreateMap<ProductDto, Product>();
            //.ForPath(dest => dest.Brand.Name, opt => opt.MapFrom(src => src.BrandName));

            CreateMap<DiscountCode, DiscountCodeDto>();
            CreateMap<DiscountCodeDto, DiscountCode>();
        }
    }
}
