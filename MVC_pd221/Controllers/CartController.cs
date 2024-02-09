using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

            //ViewBag.ToastMessage = "Product was added to your cart!";
            TempData["ToastMessage"] = "Product was added to your cart!";

            return Redirect(returnUrl);
        }

        public IActionResult Remove(int id, string returnUrl)
        {
            TempData["ToastMessage"] = "Product was removed from your cart!";

            cartService.Remove(id);
            return Redirect(returnUrl);
        }
    }
}
