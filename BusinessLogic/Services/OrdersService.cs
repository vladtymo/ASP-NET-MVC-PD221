using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BusinessLogic.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;
        private readonly IViewRender viewRender;
        private readonly UserManager<User> userManager;

        public OrdersService(IMapper mapper, 
                            ShopDbContext context, 
                            ICartService cartService,
                            IEmailSender emailSender,
                            IViewRender viewRender,
                            UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.cartService = cartService;
            this.emailSender = emailSender;
            this.viewRender = viewRender;
            this.userManager = userManager;
        }

        public async Task Create(string userId)
        {
            var ids = cartService.GetProductIds();
            var products = context.Products.Where(x => ids.Contains(x.Id)).ToList();

            User user = await userManager.FindByIdAsync(userId) ?? throw new Exception("User not found!");

            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Products = products,
                TotalPrice = products.Sum(x => x.Price),
            };

            context.Orders.Add(order);
            context.SaveChanges();

            // send order summary email
            string html = this.viewRender.Render("MailTemplates/OrderSummary", new OrderSummaryModel()
            {
                UserName = user.UserName!,
                Products = mapper.Map<IEnumerable<ProductDto>>(products),
                TotalPrice = 5656
            });

            await emailSender.SendEmailAsync("datolo1825@fahih.com", $"Order #{12}", html);
        }

        public IEnumerable<OrderDto> GetAllByUser(string userId)
        {
            var items = context.Orders.Where(x => x.UserId == userId).ToList();
            return mapper.Map<IEnumerable<OrderDto>>(items);
        }
    }
}
