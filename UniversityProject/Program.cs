using Microsoft.EntityFrameworkCore;
using ShoppingBasket.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using ShoppingBasket.DataAccess.Data;
using ShoppingBasket.Utility.DbInitializer;
using ShoppingBasket.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace UniversityProject.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc().AddXmlDataContractSerializerFormatters();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddScoped<IDbInitializer, DbInitializerRepo>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IAssignment, Assignment>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                option.LoginPath = $"/Identity/Account/Login";
                option.LogoutPath = $"/Identity/Account/Logout";
            });
           


            builder.Services.AddRazorPages();
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
            dataSedding();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
            void dataSedding()
            {
                using (var scope = app.Services.CreateScope())
                {
                    var DbInitalizer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    DbInitalizer.Initializer();
                }
            }
        }
    }
}