using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CarManagement.Application
{
    public enum CarClass
    {
        Luxus,
        Mittel,
        Einfach
    }

    public class CarDTO
    {
        public int Id { get; set; }
        public string Typ { get; set; }
        public string Brand { get; set; }
        public CarClass CarClass { get; set; }
    }
}
