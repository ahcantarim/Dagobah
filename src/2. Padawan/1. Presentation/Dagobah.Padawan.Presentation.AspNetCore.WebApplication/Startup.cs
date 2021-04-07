using Dagobah.Padawan.Presentation.AspNetCore.WebApplication.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dagobah.Padawan.Presentation.AspNetCore.WebApplication
{
    public class Startup
    {
        //private SimpleInjector.Container container = new SimpleInjector.Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDependencyInjectionConfiguration();

            //services.AddSimpleInjector(container, options =>
            //{
            //    // AddAspNetCore() wraps web requests in a Simple Injector scope and
            //    // allows request-scoped framework services to be resolved.
            //    options.AddAspNetCore()

            //        // Ensure activation of a specific framework type to be created by
            //        // Simple Injector instead of the built-in configuration system.
            //        // All calls are optional. You can enable what you need. For instance,
            //        // ViewComponents, PageModels, and TagHelpers are not needed when you
            //        // build a Web API.
            //        .AddControllerActivation()
            //        .AddViewComponentActivation()
            //        .AddPageModelActivation()
            //        .AddTagHelperActivation();

            //    // Optionally, allow application components to depend on the non-generic
            //    // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
            //    // (Microsoft.Extensions.Localization) abstractions.
            //    //options.AddLogging();
            //    //options.AddLocalization();
            //});

            //container.AddDependencyInjectionConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseSimpleInjector(container);

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
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //container.Verify();
        }
    }
}
