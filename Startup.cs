using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoelBankAppPRJ.Repository;
using VSStudioTestPRJ.Models;
using VSStudioTestPRJ.Repository;

namespace VSStudioTestPRJ
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
            services.AddDbContextPool<NoelDBContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(Configuration.GetConnectionString("NoelDBContext"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
                options.UseSqlServer(Configuration.GetConnectionString("NoelDBContext"),
                    sqlOptions => sqlOptions.CommandTimeout(60));
            });

            //services.Configure<Settings.AppSetting>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IContactListRepository, ContactListRepository>();
            services.AddTransient<IMockRepository, MockRepository>();
            //services.AddRazorPages();

            services
                .AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddJsonOptions(options => { });

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes
                .MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes
                .MapRoute(
                    name: "Person",
                    template: "{controller=Pserson}/{action=Index}");
            });

        }
    }
}
