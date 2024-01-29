using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC_pd221.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public ProductsController(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private void LoadCategories()
        {
            // TempData[key] = value; - not-typing obejcts
            // ViewBag.Key = value;   - typed elements
            ViewBag.Categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
        }

        public IActionResult Index()
        {
            var products = context.Products.Include(x => x.Category).ToList();

            return View(products);
        }

        public IActionResult Details(int id, string? returnUrl)
        {
            // with JOIN operators
            //var product = context.Products.Include(x => x.Category).FirstOrDefault(i => i.Id == id);
            // without JOIN operators
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            // load product related entity
            context.Entry(product).Reference(x => x.Category).Load();

            ViewBag.ReturnUrl = returnUrl;

            return View(product);
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
            }

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

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
            }

            // update product in the db
            context.Products.Update(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // delete by id
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
