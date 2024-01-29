using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Data.Entities;

namespace BusinessLogic.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductModel, Product>().ReverseMap();
        }
    }
}
