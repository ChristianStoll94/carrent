using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ContractManagement.Application;

namespace CarRent.ContractManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("{id}")]
        public ContractDTO Get(int id)
        {
            return _contractService.GetContract(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromQuery] int reservationId)
        {
            _contractService.CreateConract(reservationId);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contractService.DeleteContract(id);
        }
    }
}
