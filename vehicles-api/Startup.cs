using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using vehicles_api.Models;

namespace vehicles_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VehicleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, VehicleDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!dbContext.Vehicles.Any())
            {
                VehicleSeeder vehicleSeeder = new VehicleSeeder(dbContext);
                vehicleSeeder.SeedData();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
