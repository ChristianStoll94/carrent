using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;

namespace CarRent.Seed
{
    public static class BaseSeed
    {
        public static CarClass[] CarClasses => new CarClass[]
        {
            new CarClass() {Description = "Einfachklasse", Price = 13.50},
            new CarClass() {Description = "Mittelklasse", Price = 20.60},
            new CarClass() {Description = "Luxusklasse", Price = 35.45}
        };

    }
}
