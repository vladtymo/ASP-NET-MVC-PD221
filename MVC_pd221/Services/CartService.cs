using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using MVC_pd221.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace MVC_pd221.Services
{
    public class CartService : ICartService
    {
        const string key = "cart_item_key";
        private readonly HttpContext httpContext;
        private readonly IProductsService productsService;

        public CartService(IHttpContextAccessor httpContextAccessor, IProductsService productsService)
        {
             this.httpContext = httpContextAccessor.HttpContext!;
            this.productsService = productsService;
        }

        private void SaveItems(List<int> items)
        {
            //httpContext.Session.SetString(key, JsonSerializer.Serialize(items));
            httpContext.Session.Set(key, items);
        }
        private List<int>? GetItems()
        {
            //var value = httpContext.Session.GetString(key);
            // return value == null ? default : JsonSerializer.Deserialize<List<int>>(value);
            return httpContext.Session.Get<List<int>>(key);
        }

        public int GetCount()
        {
            return GetItems()?.Count ?? 0;
        }

        public void Add(int id)
        {
            // get existing items in the cart
            var ids = GetItems();

            if (ids == null) ids = new();
            ids.Add(id);

            // save items to the cart
            SaveItems(ids);
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            IEnumerable<int> ids = GetItems() ?? Enumerable.Empty<int>();
            return productsService.Get(ids);
        }

        public void Remove(int id)
        {
            // get existing items in the cart
            var ids = GetItems();

            if (ids == null) return;
            ids.Remove(id);

            // save items to the cart
            SaveItems(ids);
        }

        public bool IsExists(int id)
        {
            IEnumerable<int>? ids = GetItems();

            if (ids == null) return false;

            return ids.Contains(id);
        }
    }
}
