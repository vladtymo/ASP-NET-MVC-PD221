using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MVC_pd221.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(cartService.GetProducts());
        }

        public IActionResult Add(int id, string returnUrl)
        {
            cartService.Add(id);
            return Redirect(returnUrl);
        }

        public IActionResult Remove(int id, string returnUrl)
        {
            cartService.Remove(id);
            return Redirect(returnUrl);
        }
    }
}
