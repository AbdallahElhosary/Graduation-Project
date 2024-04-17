using Microsoft.EntityFrameworkCore;
using NewProject.Data;
using NewProject.Services;

namespace NewProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var con = builder.Configuration.GetConnectionString("Default") ??
               throw new InvalidOperationException("not database found");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(con));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITendersService, TendersService>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<INeededItemService, NeededItemService>();
            builder.Services.AddScoped<ICommitteeService, CommitteeService>();
            builder.Services.AddScoped<IValidItemService , ValidItemService>();
            builder.Services.AddScoped<IVendorService, VendorService>();
            builder.Services.AddScoped<IOfferService , OfferService>();
            builder.Services.AddScoped<IAlternativeItemService, AlternativeItemService>();


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
