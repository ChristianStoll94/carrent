using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ContractManagement.Domain;
using CarRent.ReservationManagement.Domain;

namespace CarRent.CarManagement.Domain
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Typ { get; set; }
        public CarClass CarClass { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}