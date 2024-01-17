using Microsoft.AspNetCore.Mvc;
using MVC_pd221.Data;

namespace MVC_pd221.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext context;

        public ProductsController(ShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();

            return View(products);
        }
    }
}
