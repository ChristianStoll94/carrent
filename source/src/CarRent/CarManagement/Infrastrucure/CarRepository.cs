using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Infrastrucure
{
    public class CarRepository : ICarRepository
    {
        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> FindByFilter(CarDTO car)
        {
            throw new NotImplementedException();
        }

        public void Add(CarDTO customerdto)
        {
            throw new NotImplementedException();
        }

        public void Update(CarDTO customerdto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
