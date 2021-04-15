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
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

using ProjectFinal.DataConnect;
using ProjectFinal.Models;

namespace ProjectFinal
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
            services.AddControllersWithViews();

            services.AddDbContext<DbContextApp>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<DbPassportUserModel, IdentityRole>(
               config =>
               {
                   config.SignIn.RequireConfirmedEmail = false;
                   config.SignIn.RequireConfirmedPhoneNumber = false;
                   config.SignIn.RequireConfirmedAccount = false;


               }).AddEntityFrameworkStores<DbContextApp>(

               ).AddDefaultTokenProviders();
            var mailKitOptions = Configuration.GetSection("Email").Get<MailKitOptions>();
            services.AddMailKit(
                config =>
                {
                    config.UseMailKit(mailKitOptions);

                }


                );
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Register/SignIn");
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Register/CustomError");

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
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
