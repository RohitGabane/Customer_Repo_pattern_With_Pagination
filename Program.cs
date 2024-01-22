using Customer_Repo_Pattern.Models;
using Customer_Repo_Pattern.Service;
using Microsoft.EntityFrameworkCore;

namespace Customer_Repo_Pattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepositoryImplementation>();

            //Amazatics
           var b= builder.Configuration.GetConnectionString("Amazatics");
            builder.Services.AddDbContext<CustomerDbContext>((op) => op.UseSqlServer(b));

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
                pattern: "{controller=Customer}/{action=Index}");

            app.Run();
        }
    }
}