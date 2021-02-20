using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.ContractManagement.Application
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public double Price { get; set; }
    }
}
