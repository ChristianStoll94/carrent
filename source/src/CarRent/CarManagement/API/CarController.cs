using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CarManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<CarDTO> Get([FromQuery] CarDTO carDto)
        {
            return _carService.GetCarByFilter(carDto);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarDTO Get(int id)
        {
            return _carService.GetCar(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromQuery] CarDTO carDto)
        {
            _carService.CreateCar(carDto);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Put([FromQuery] CarDTO carDto)
        {
            _carService.UpdateCar(carDto);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carService.DeleteCar(id);
        }
    }
}
