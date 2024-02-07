using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Models;
using DataAccess.Data.Entities;

namespace BusinessLogic.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Category, opts => opts.Ignore());

            CreateMap<CreateProductModel, Product>().ReverseMap();
            CreateMap<EditProductModel, Product>().ReverseMap();
          
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
