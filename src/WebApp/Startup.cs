using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Services.Concrete;
using Application.Infrastructure.Persistence;
using Application;

namespace WebApp
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

            services.AddDbContext<CarRentalDbContext>();
            services.AddScoped<ICarRentalDbContext>(provider => provider.GetService<CarRentalDbContext>());

            services.AddScoped<IVehicleBrandService, VehicleBrandService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IColorTypeService, ColorTypeService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IRentalPeriodService, RentalPeriodService>();
            services.AddScoped<ITireTypeService, TireTypeService>();
            services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();
            services.AddScoped<IVehicleClassTypeService, VehicleClassTypeService>();
            services.AddScoped<IVehicleRentalPriceService, VehicleRentalPriceService>();
            services.AddScoped<IVehicleService, VehicleService>();

            services.AddApplicationServices();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}