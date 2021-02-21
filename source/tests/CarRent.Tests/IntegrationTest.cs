using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.Models.DBModels;
using CarRent.Seed;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CarRent.Tests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        public readonly carrentContext _carrentContext;

        protected IntegrationTest()
        {
            //Start Projekt with MemoryDatabase

            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                 typeof(DbContextOptions<carrentContext>));

                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }

                        services.AddDbContext<carrentContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            //AddTestClient
            TestClient = appFactory.CreateClient();

            //AddTestData
            using (var scope = appFactory.Services.CreateScope())
            {
                _carrentContext = scope.ServiceProvider.GetRequiredService<carrentContext>();

                _carrentContext.CarClass.AddRange(BaseSeed.CarClasses);
                _carrentContext.SaveChanges();

                var Customer = new[]
                {
                    new Customer {Id = 1, Name = "bernd", Address = "Auenland"},
                    new Customer {Id = 2, Name = "Peter", Address = "Bern"}
                };
                _carrentContext.Customer.AddRange(Customer);

                var bla = _carrentContext.CarClass.FirstOrDefault();

                var Car = new[]
                {
                    new Car {Id = 1, Brand = "Audi", Typ = "Cabrio", CarClass = _carrentContext.CarClass.FirstOrDefault(o => o.Description == "Einfachklasse")},
                    new Car {Id = 2, Brand = "Ford", Typ = "Combi", CarClass = _carrentContext.CarClass.FirstOrDefault(o => o.Description == "Mittelklasse")}
                };
                _carrentContext.Car.AddRange(Car);

                _carrentContext.SaveChanges();
            }
        }
    }
}
