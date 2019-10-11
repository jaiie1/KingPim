using KingPim.Data;
using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using KingPim.Repositories.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KingPim.Web
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration conf)
        {
            _configuration = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Configuration for DB connection.
            var conn = _configuration.GetConnectionString("KingPim");
            // Register all services here:
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conn));

            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IIdentitySeed, IdentitySeed>();
            services.AddTransient<IRoleSeed, RoleSeed>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ISubCategory, SubCategoryRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IAttributeGroup, AttributeGroupRepository>();
            services.AddTransient<IOneAttribute, OneAttributeRepository>();
            services.AddTransient<IProductOneAttributeValues, ProductOneAttributeValuesRepository>();
            services.AddTransient<IPredefinedAttrList, PredefinedAttrlistRepository>();
            services.AddTransient<IPredefinedOneAttributeListOptions, PredefinedOneAttributeListOptionsRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;
            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromDays(2));

            services.AddMvc()

                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx, IIdentitySeed identitySeed, IRoleSeed roleSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "details",
                    template: "{controller=Product}/{action=Details}/{id?}");
            });

            var runIdentitySeed = Task.Run(async () => await identitySeed.CreateAdminAccountIfEmpty()).Result;
            var runRoleSeed = Task.Run(async () => await roleSeed.CreateRoleIfEmpty()).Result;
        }
    }
}