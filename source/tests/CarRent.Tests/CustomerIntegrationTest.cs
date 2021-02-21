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
using RestSharp;

namespace CarRent.Tests
{
    public class CustomerIntegrationTest : IntegrationTest
    {
        
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task CustomerEndpoint_GetCustomer_Get200Ok()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("https://localhost:5001/api/Customer/1");
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CustomerEndpoint_DeleteCustomer_Get200Ok()
        {
            //Arrange

            //Act
            var response = await TestClient.DeleteAsync("https://localhost:5001/api/Customer/2");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CustomerEndpoint_PostCustomer_Get200Ok()
        {
            ////Arrange

            ////Act
            var response = await TestClient.PostAsync("https://localhost:5001/api/Customer?Id=3&Name=ueli&Address=schmid", null);

            ////Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}