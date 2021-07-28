using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using CoffeeRoastManagement.Server.Entities;
using CoffeeRoastManagement.Shared;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace CoffeeRoastManagement.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMudServices();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            // Consider two different sources for the connection string: environment variable, appsettings.json
            if (!String.IsNullOrEmpty(Configuration["CONNECTION_STRING"]))
            {
                services.AddDbContext<RoastDbContext>(options =>
                      options.UseSqlServer(Configuration.GetConnectionString("CoffeeRoastDatabase")), ServiceLifetime.Transient);
            }
            else if (!String.IsNullOrEmpty(Configuration.GetConnectionString("CoffeeRoastDatabase")))
            {
                services.AddDbContext<RoastDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("CoffeeRoastDatabase")), ServiceLifetime.Transient);
            }
            else
            {
                throw new ApplicationException(
                    "No connection string given. Either define the environment variable \"CONNECTION_STRING\" or set the connection string in appsettings.json (\"ConnectionStrings\" { \"CoffeeRoastDatabase\" }).");
            }

            services.AddDbContext<Entities.RoastDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<RoastDbContext>();
                context.Database.Migrate();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
