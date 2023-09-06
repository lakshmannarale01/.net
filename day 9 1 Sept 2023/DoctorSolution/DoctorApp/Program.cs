using DoctorApp.Contexts;
using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;
using DoctorApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region AddingConetexts
            builder.Services.AddDbContext<DoctorAppContexts>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion
            #region AddingUserderfinedServices
            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorsRepository>();
            builder.Services.AddScoped<IRepository<int, Patient>, PatientRepository>();
            builder.Services.AddScoped<IRepository<int, Appointment>, AppointmentRepository>();
            #endregion
            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // time postgress sobat set karnyasathi

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}