using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_pd221.Helpers;

namespace MVC_pd221.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductsService productsService;

        public ProductsController(IMapper mapper, IProductsService productsService)
        {
            this.mapper = mapper;
            this.productsService = productsService;
        }

        private void LoadCategories()
        {
            // TempData[key] = value; - not-typing obejcts
            // ViewBag.Key = value;   - typed elements
            var categoris = productsService.GetAllCategories();
            ViewBag.Categories = new SelectList(categoris, nameof(CategoryDto.Id), nameof(CategoryDto.Name));
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(productsService.GetAll());
        }

        [AllowAnonymous]
        public IActionResult Details(int id, string? returnUrl)
        {
            var product = productsService.Get(id);
            if (product == null) return NotFound();

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

            // logic
            productsService.Create(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = productsService.Get(id);
            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(EditProductModel model)
        {
            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
            }

            productsService.Edit(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
