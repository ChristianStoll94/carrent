using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.ContractManagement.Domain
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public double Price { get; set; }
    }
}
