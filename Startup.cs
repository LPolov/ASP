using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Areas.Account.Data.Repositories;
using OnlineShop.Areas.Account.Mappers;
using OnlineShop.Areas.Account.Mappers.Impl;
using OnlineShop.Areas.Account.Services;
using OnlineShop.Areas.Account.Services.Impl;
using OnlineShop.Areas.Chat.Data;
using OnlineShop.Areas.Customer.Data;
using OnlineShop.Areas.Customer.Mappers;
using OnlineShop.Areas.Customer.Mappers.Impl;
using OnlineShop.Areas.Customer.Services;
using OnlineShop.Data;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
           services.AddRazorPages();
           services.AddSignalR();
           //Add Services to context
           services.AddTransient<IProductService, DefaultProductService>();
           services.AddTransient<ICategoryService, DefaultCategoryService>();
           services.AddTransient<IUserService, DefaultUserService>();
           //Add repositories
           services.AddTransient<ProductsRepository>();
           services.AddTransient<CategoryRepository>();
           services.AddTransient<UserRepository>();
           //Add mappers
           services.AddTransient<IProductMapper, DefaultProductMapper>();
           services.AddTransient<ICategoryMapper, DefaultCategoryMapper>();
           services.AddTransient<IUserMapper, DefaultUserMapper>();
           
           //Authentication
           services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Account/User/Login";
               }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                    name: "account",
                    areaName: "Account",
                    pattern: "Account/{controller=User}/{action=Login}/{id?}"
                );
                
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Product}/{action=Products}/{id?}"
                );
                
                endpoints.MapAreaControllerRoute(
                    name: "customer",
                    areaName: "Customer",
                    pattern: "Customer/{controller=Product}/{action=Index}"
                );
                
                endpoints.MapHub<ChatHub>("/chat/Chat/Index");
                endpoints.MapAreaControllerRoute(
                    name: "chat",
                    areaName: "Chat",
                    pattern: "Chat/{controller=Chat}/{action=Index}"
                );
                endpoints.MapRazorPages();
            });
        }
    }
}
