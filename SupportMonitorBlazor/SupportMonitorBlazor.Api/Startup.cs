using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SupportMonitorBlazor.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api
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
            services.AddDbContext<appDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddControllers();
            services.AddScoped<IBlazorTmsRepository, BlazorTmsRepository>();
            services.AddScoped<ITmsErrorsRepository, TmsErrorsRepository>();
            services.AddScoped<ISystemValuesRepository, SystemValuesRepository>();
            services.AddScoped<IDiskSpaceRepository, DiskSpaceRepository>();
            services.AddScoped<ITmsPropertiesRepository, TmsPropertiesRepository>();
            services.AddScoped<ITMS_ServicesRepository, TMS_ServicesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
