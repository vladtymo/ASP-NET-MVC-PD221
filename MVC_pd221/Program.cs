using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using DataAccess.Data;
using BusinessLogic.Mapping;
using BusinessLogic;
using DataAccess;
using BusinessLogic.Services;
using MVC_pd221.Helpers;
using Microsoft.AspNetCore.Identity;
using DataAccess.Data.Entities;
using BusinessLogic.Interfaces;
using MVC_pd221.Services;

namespace MVC_pd221
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connStr = builder.Configuration.GetConnectionString("LocalDb")!;

            // Add services to the container.
            // DI - Dependency Injection. It implements SOLI[D] principle Dependency Inversion
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext(connStr);

            builder.Services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ShopDbContext>();

            // auto mapper configuration
            builder.Services.AddAutoMapper();
            // fluent validators configuration
            builder.Services.AddFluentValidator();

            // add custom servies
            builder.Services.AddCustomServices();
            builder.Services.AddCartService();
            //builder.Services.AddScoped<ICartService, CartService>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // seed roles and admin
            // app.Services.SeedAdmin();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                serviceProvider.SeedRoles().Wait();
                serviceProvider.SeedAdmin().Wait();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // check user account
            app.UseAuthorization();  // give access base on roles

            app.UseSession();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
