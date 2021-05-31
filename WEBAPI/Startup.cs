using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using DATA.Repos;
using BUSINESS.Interfaces;
using BUSINESS.Services;

namespace WEBAPI
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
            services.AddScoped<ICarRep, CarRep>();
            services.AddScoped<IDescRep, DescRep>();
            services.AddScoped<ICustomerRep, CustomerRep>();
            services.AddScoped<IOrderRep, OrderRep>();
            services.AddScoped<ISellerRep, SellerRep>();
            services.AddScoped<IWorkerRep, WorkerRep>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarServ, CarServ>();
            services.AddScoped<ICustomerServ, CustomerServ>();
            services.AddScoped<IDescServ, DescServ>();
            services.AddScoped<IOrderServ, OrderServ>();
            services.AddScoped<ISellerServ, SellerServ>();
            services.AddScoped<IWorkerServ, WorkerServ>();
            services.AddDbContext<MyContext>(op => op.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

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
