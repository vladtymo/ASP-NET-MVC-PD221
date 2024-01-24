using AutoMapper;
using MVC_pd221.Data.Entities;
using MVC_pd221.Models;

namespace MVC_pd221.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductModel, Product>().ReverseMap();
        }
    }
}
