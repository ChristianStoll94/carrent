using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ReservationManagement.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.ReservationManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        //Swagger DateTimeFormat Example: 2017-07-21T17:32:28Z

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public ReservationDTO Get(int id)
        {
            return _reservationService.GetReservation(id);
        }

        [HttpGet("/price")]
        public double GetPrice([FromQuery] CalculationQuery calculationQuery)
        {
            return _reservationService.GetPrice(calculationQuery);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromQuery] ReservationDTO reservationDto)
        {
            _reservationService.CreateReservation(reservationDto);
        }

        // PUT api/<ReservationController>/5
        [HttpPut]
        public void Put([FromQuery] ReservationDTO reservationDto)
        {
            _reservationService.UpdateReservation(reservationDto);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reservationService.DeleteReservation(id);
        }
    }
}
