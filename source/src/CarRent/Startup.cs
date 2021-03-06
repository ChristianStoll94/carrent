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
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Domain;
using CarRent.CarManagement.Infrastrucure;
using CarRent.ContractManagement.Application;
using CarRent.ContractManagement.Domain;
using CarRent.ContractManagement.Infrastructure;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure;
using CarRent.Models.DBModels;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Domain;
using CarRent.ReservationManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarRent
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

            services.AddDbContext<carrentContext>(options => options.UseMySql(Configuration.GetConnectionString("carrentContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRent", Version = "v1" });

            });
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarRepository, CarRepository>();

            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IReservationRepository, ReservationRepository>();

            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IContractRepository, ContractRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRent v1"));
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
