using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Inventory.AccountTooles;
using Inventory.AccountTooles.Filters;
using Inventory.GenericClasses;
using Inventory.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ElmahCore.Mvc;
using AutoMapper;
using ElmahCore;
using StackExchange.Profiling.Storage;

namespace Inventory
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //----------------------------------------------------------------------------------------------------------------
            // Set Your DataBase Configuration  
            //----------------------------------------------------------------------------------------------------------------
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

            //----------------------------------------------------------------------------------------------------------------
            // Configur Account Tools :
            //              1- (Custom Authorization) Add Action Filter So i can Use it As Action Attribute above any Controller or and Controller.Action
            //              2- Override IUserClaimsPrincipalFactory so i can Add Claims To Logged In User
            //----------------------------------------------------------------------------------------------------------------
            services.AddScoped<HasPermissionTo>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();

            //----------------------------------------------------------------------------------------------------------------
            // ElmahCore {Exceptions Logger Library}
            //----------------------------------------------------------------------------------------------------------------
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.FiltersConfig = "elmah.xml";
                options.LogPath = "~/log"; // OR options.LogPath = "с:\errors";
                options.CheckPermissionAction = context => (context.User.Identity.IsAuthenticated && context.User.IsInRole(nameof(ApplicationRole.SuperAdmin)));
                

            });
            //services.AddElmah(options =>
            //{
            //    // Check if user isInRole SuperAdmin
            //    options.CheckPermissionAction = context => (context.User.Identity.IsAuthenticated && context.User.IsInRole(nameof(ApplicationRole.SuperAdmin)));
                
            //});

            //----------------------------------------------------------------------------------------------------------------
            // Adding Asp Identity with custom implementation for (IdentityUser,IdentityRole) =in =>(ApplicationUser , ApplicationRole)
            //----------------------------------------------------------------------------------------------------------------
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            //----------------------------------------------------------------------------------------------------------------
            // Add AutoMapper // https://medium.com/ps-its-huuti/how-to-get-started-with-automapper-and-asp-net-core-2-ecac60ef523f
            // NOTE : When our application starts up and adds AutoMapper, AutoMapper will scan our assembly and look for classes that inherit from Profile, then load their mapping configurations.
            //----------------------------------------------------------------------------------------------------------------
            services.AddAutoMapper();

            //----------------------------------------------------------------------------------------------------------------
            // Add MVC Version_2_2 With Localization To Support trnslate Multi Lang in Controller and Views And Models
            //----------------------------------------------------------------------------------------------------------------
            services.AddLocalization(opts => opts.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization(
                        LanguageViewLocationExpanderFormat.Suffix,
                        opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                opts.DefaultRequestCulture = new RequestCulture(Lang.DefaultLang);
                // Formatting numbers , dates , etc.
                opts.SupportedCultures = Lang.supportedCultures;
                // UI strings that we have localized
                opts.SupportedUICultures = Lang.supportedUICultures;

            });

            //----------------------------------------------------------------------------------------------------------------
            // mini Profiler {Preformance Monitor Library} https://miniprofiler.com/dotnet/
            //----------------------------------------------------------------------------------------------------------------
            services.AddMiniProfiler(options =>
            {
                // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

                // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
                options.RouteBasePath = "/profiler";

                // (Optional) Control storage
                // (default is 30 minutes in MemoryCacheStorage)
                (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);

                // (Optional) Control which SQL formatter to use, InlineFormatter is the default
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();

                // To control authorization, you can use the Func<HttpRequest, bool> options:
                options.ResultsAuthorize = request => request.HttpContext.User.IsInRole(nameof(ApplicationRole.SuperAdmin));

                // (Optional) You can disable "Connection Open()", "Connection Close()" (and async variant) tracking.
                // (defaults to true, and connection opening/closing is tracked)
                options.TrackConnectionOpenClose = true;
            }).AddEntityFramework();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();


            //----------------------------------------------------------------------------------------------------------------
            // ElmahCore {Exceptions Logger Library}
            //----------------------------------------------------------------------------------------------------------------
            app.UseElmah();
            //----------------------------------------------------------------------------------------------------------------
                        
            //----------------------------------------------------------------------------------------------------------------
            // mini Profiler {Preformance Monitor Library} https://miniprofiler.com/dotnet/
            //----------------------------------------------------------------------------------------------------------------
            app.UseMiniProfiler();
            //----------------------------------------------------------------------------------------------------------------
            
            //----------------------------------------------------------------------------------------------------------------
            // Add globalization and localization to pipline  
            //----------------------------------------------------------------------------------------------------------------
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
