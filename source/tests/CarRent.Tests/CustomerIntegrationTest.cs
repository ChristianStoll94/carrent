using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Domain;
using CarRent.Models.DBModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CarRent.Tests
{
    public class CustomerIntegrationTest : IntegrationTest
    {
        
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task CustomerEndpoint_PostNewCustomer_Get200Ok()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("https://localhost:5001/api/Car/1");
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //var responseContent = await response.Content.ReadAsStringAsync();
            //var Cardto2 = JsonConvert.DeserializeObject<CarDTO>(responseContent);
            //(await response.Content.ReadAsStringAsync()).Should().BeEmpty();
        }

        [Test]
        public async Task CustomerEndpoint_DeleteCustomer_Get200Ok()
        {
            //Arrange

            //Act
            var response = await TestClient.DeleteAsync("https://localhost:5001/api/Car/1");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public async Task CustomerEndpoint_PostCustomer_Get200Ok()
        {
            //Arrange
            var Customer = new CustomerDTO()
            {
                Name = "Klaus",
                Address = "Weinfelden",
            };
            string JsonString = JsonConvert.SerializeObject(Customer);

            //Act
            var response = await TestClient.PostAsync("https://localhost:5001/api/Car/1", JsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}