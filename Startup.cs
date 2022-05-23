using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RosreestDocks.Contexts;
using RosreestDocks.Helpers;
using RosreestDocks.Models;
using System;

namespace RosreestDocks
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

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;

            });

            services.AddControllersWithViews();
                       
            services.AddDefaultIdentity<User>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
                config.User.RequireUniqueEmail = true;
                config.SignIn.RequireConfirmedAccount = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<DataBaseContext>();

            services.AddDbContext<DataBaseContext>();
            services.AddScoped<DocksService>();
            services.AddScoped<FileService>();
            services.AddScoped<EgrulService>();
            services.AddScoped<DatabaseService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddControllersWithViews();
            services.AddMvc();
            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Error/PageNotFound";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Remove",
                    pattern: "{controller=Data}/{action=Remove}/{modelType}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Foiv",
                    pattern: "{controller=Data}/{action=ShowCreateFoivModal}");

                endpoints.MapControllerRoute(
                    name: "Foiv",
                    pattern: "{controller=Data}/{action=ShowUpdateFoivModal}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Foiv",
                    pattern: "{controller=Data}/{action=ShowRemoveFoivModal}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Organization",
                    pattern: "{controller=Data}/{action=ShowUpdateOrganizationModal}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Organization",
                    pattern: "{controller=Data}/{action=ShowCreateOrganizationModal}");

                endpoints.MapControllerRoute(
                    name: "Acronyms",
                    pattern: "{controller=Data}/{action=ShowCreateAcronymsModal}");

                endpoints.MapControllerRoute(
                    name: "DocCat",
                    pattern: "{controller=Data}/{action=ShowUpdateDocCategoryModal}/{id?}");

                endpoints.MapControllerRoute(
                    name: "DocCat",
                    pattern: "{controller=Data}/{action=ShowCreateDocCategoryModal}");

                endpoints.MapControllerRoute(
                    name: "Doc",
                    pattern: "{controller=Data}/{action=ShowUpdateDocumentModal}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Doc",
                    pattern: "{controller=Data}/{action=ShowCreateDocumentModal}");

                endpoints.MapControllerRoute(
                    name: "Doc",
                    pattern: "{controller=Data}/{action=DownloadDocument}/{id?}");

                endpoints.MapControllerRoute(
                    name: "UpdateAg",
                    pattern: "{controller=Data}/{action=UpdateAgencies}/");

                endpoints.MapControllerRoute(
                    name: "Consider",
                    pattern: "{controller=Home}/{action=AppealConsider}/");

                endpoints.MapControllerRoute(
                    name: "EditConsider",
                    pattern: "{controller=Data}/{action=EditAppealConsider}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Appeals",
                    pattern: "{controller=Data}/{action=Appeals}/");

                endpoints.MapControllerRoute(
                        name: "CreateAppeals",
                        pattern: "{controller=Data}/{action=CreateAppealConsider}/");

                endpoints.MapControllerRoute(
                        name: "CreateAppealRunner",
                        pattern: "{controller=Data}/{action=CreateAppealRunner}/");

                endpoints.MapControllerRoute(
                    name: "CreateZapros",
                    pattern: "{controller=Data}/{action=CreateZaprosCentral}/");

                endpoints.MapControllerRoute(
                    name: "RemoveNote",
                    pattern: "{controller=Data}/{action=RemoveNote}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
