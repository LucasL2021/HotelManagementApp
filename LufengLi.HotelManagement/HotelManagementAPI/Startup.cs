using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Repositories;

namespace HotelManagementAPI
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

            services.AddControllers();

            services.AddControllersWithViews();

            // DI
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            //services.AddScoped<IRoomService, RoomService>();

            services.AddDbContext<HotelManagementDbContext>(options =>
                options.UseSqlServer(Configuration
                    .GetConnectionString("HotelManagementDbConnection")));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelManagementAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelManagementAPI v1"));
            }
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
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
