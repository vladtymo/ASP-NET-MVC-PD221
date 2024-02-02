using BusinessLogic.Interfaces;
using MVC_pd221.Services;

namespace MVC_pd221.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddCartService(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
        }
    }
}
