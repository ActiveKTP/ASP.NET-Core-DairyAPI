using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DairyAPI
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

            /*services.AddDbContext<CowContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("DairyConnection")));

            services.AddDbContext<FarmContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("DairyConnection")));*/

            services.AddDbContext<DairyContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("DairyConnection")));

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICowRepo, CowRepo>();

            services.AddScoped<IFarmRepo, FarmRepo>();

            services.AddScoped<IMatingRepo, MatingRepo>();

            services.AddScoped<ICalvingRepo, CalvingRepo>();

            services.AddScoped<ICalveRepo, CalveRepo>();

            services.AddScoped<IGrowthRepo, GrowthRepo>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DairyAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DairyAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAnyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
