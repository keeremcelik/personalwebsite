using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebUI.Models;
using WebUI.Infrastructer;
using WebUI.Data.Concrete.EfCore;
using WebUI.Data.Abstract;

namespace WebUI
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
            services.AddRazorPages();
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAbilityRepository, EfAbilityRepository>();
            services.AddTransient<ICategoryRepository, EfCategoryRepository>();
            services.AddTransient<ICommentRepository, EfCommentRepository>();
            services.AddTransient<IMessageRepository, EfMessageRepository>();
            services.AddTransient<IPersonalSettingRepository, EfPersonalSettingRepository>();
            services.AddTransient<IPostRepository, EfPostRepository>();
            services.AddTransient<IProjectRepository, EfProjectRepository>();
            services.AddTransient<ISiteSettingRepository, EfSiteSettingRepository>();
            services.AddTransient<ISocialRepository, EfSocialRepository>();
            services.AddTransient<IImageRepository, EfImageRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.User.AllowedUserNameCharacters = "abcdefgklmnoprstuvyzxw";
              
            })           
           .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
           .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Blog}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "panel",
                    pattern: "panel/{controller=Panel}/{action=Index}");

                endpoints.MapControllerRoute(
                   name: "setting",
                   pattern: "panel/setting/{controller=Panel}/{action=Index}");

            

            });
        }
    }
}
