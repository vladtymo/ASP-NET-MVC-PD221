using BusinessLogic.Interfaces;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_pd221.Models;
using System.Diagnostics;

namespace MVC_pd221.Controllers
{
    public class HomeController : Controller
    {
        private List<Contact> contacts = new();
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            contacts.Add(new Contact() { Id = 1000, Name = "Bob", Phone = "+380987654321" });
            contacts.Add(new Contact() { Id = 1003, Name = "Olga", Phone = "45-66-33" });
            contacts.Add(new Contact() { Id = 1006, Name = "Alex", Phone = "0674455332" });

            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            ViewBag.ProductsCount = productsService.GetCount();
            return View(productsService.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View(contacts); // ~/Views/Home/Contacts.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
