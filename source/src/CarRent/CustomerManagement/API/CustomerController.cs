using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CarRent.CustomerManagement.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CustomerManagement.API
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet("byname/{name}")]
        public IEnumerable<CustomerDTO> Get(string name)
        {
            return  _customerService.GetCustomersByName(name);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {

            return _customerService.GetCustomer(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromQuery] CustomerDTO customer)
        {
            _customerService.CreateCustomer(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public void Put([FromQuery] CustomerDTO customer)
        {
            _customerService.UpdateCustomer(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
