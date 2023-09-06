using EmployeeLoginApplication.Contexts;
using EmployeeLoginApplication.interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Repositories;
using EmployeeLoginApplication.Services;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmployeeLoginApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DatabaseConnection 
            #region AddingConetexts
            builder.Services.AddDbContext<EmployeeContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
           
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ILoginService, LoginService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=UserLogin}/{id?}"); 

            app.Run();
        }
    }
}