using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using DataAccess.Data;
using BusinessLogic.Mapping;
using BusinessLogic;

namespace MVC_pd221
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("LocalDb");

            // Add services to the container.
            // DI - Dependency Injection. It implements SOLI[D] principle Dependency Inversion
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ShopDbContext>(opts => 
                opts.UseSqlServer(connStr));

            // auto mapper
            builder.Services.AddAutoMapper();

            builder.Services.AddFluentValidator();

            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
