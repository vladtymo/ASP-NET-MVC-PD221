using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Data.Entities;

namespace BusinessLogic.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IFileService fileService)
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Category, opts => opts.Ignore());

            CreateMap<CreateProductModel, Product>()
                .ForMember(x => x.ImageUrl, opts => opts.MapFrom(p => fileService.SaveProductImage(p.Image).Result));

            CreateMap<EditProductModel, Product>().ReverseMap();
          
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
