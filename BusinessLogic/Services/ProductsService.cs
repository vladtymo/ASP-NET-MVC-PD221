using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    internal class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;

        public ProductsService(IMapper mapper, ShopDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void Create(CreateProductModel model)
        {
            // convert model to entity type
            // 1 - manually
            //var entity = new Product()
            //{
            //    Name = model.Name,
            //    Description = model.Description,
            //    CategoryId = model.CategoryId,
            //    Discount = model.Discount,
            //    ImageUrl = model.ImageUrl,
            //    InStock = model.InStock,
            //    Price = model.Price
            //};
            // 2 - using AutoMapper
            var entity = mapper.Map<Product>(model);

            // create product in the db
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // delete by id
            var product = context.Products.Find(id);
            if (product == null) return; // TODO: throw exceptions

            context.Products.Remove(product);
            context.SaveChanges();

        }

        public void Edit(EditProductModel model)
        {
            var entity = mapper.Map<Product>(model);

            // update product in the db
            context.Products.Update(entity);
            context.SaveChanges();
        }

        public ProductDto? Get(int id)
        {
            // with JOIN operators
            //var product = context.Products.Include(x => x.Category).FirstOrDefault(i => i.Id == id);
            // without JOIN operators
            var product = context.Products.Find(id);
            if (product == null) return null;

            // load product related entity
            context.Entry(product).Reference(x => x.Category).Load();

            return mapper.Map<ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return mapper.Map<List<ProductDto>>(context.Products.Include(x => x.Category).ToList());
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return mapper.Map<List<CategoryDto>>(context.Categories.ToList());
        }

        public int GetCount()
        {
            return context.Products.Count();
        }
    }
}
