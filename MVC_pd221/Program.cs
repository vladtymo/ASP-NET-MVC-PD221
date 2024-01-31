using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using DataAccess.Data;
using BusinessLogic.Mapping;
using BusinessLogic;
using DataAccess;
using BusinessLogic.Services;

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

            // auto mapper configuration
            builder.Services.AddAutoMapper();
            // fluent validators configuration
            builder.Services.AddFluentValidator();

            // add custom servies
            builder.Services.AddCustomServices();

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
