
using Microsoft.EntityFrameworkCore;
using BlogApplication.Interfaces;
using System.Numerics;
using BlogApplication.BlogContext;
using BlogApplication.repositories;
using BlogApplication.Models;
using BlogApplication.Services;

namespace HospitalClinicApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region AddingConetexts
            builder.Services.AddDbContext<BContexts>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region injection
            builder.Services.AddScoped<IRepository<int , Author >,AuthorRepository>();
            builder.Services.AddScoped<IRepository<int, BlogPost>, BlogPostRepository>();
            builder.Services.AddScoped<IRepository<int, CategoryTag>, CategoryTagRepository>();

            builder.Services.AddScoped<IAuthorService , AuthorService>();
            builder.Services.AddScoped<IBlogPostService, BlogPostService>();
            builder.Services.AddScoped<ICategoryTagService, CategoryTagService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            #endregion

            var app = builder.Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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