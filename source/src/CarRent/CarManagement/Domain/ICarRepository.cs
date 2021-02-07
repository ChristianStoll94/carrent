using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;

namespace CarRent.CarManagement.Domain
{
    public interface ICarRepository
    {
        Car Get(int id);

        IEnumerable<Car> FindByFilter(CarDTO car);

        void Add(CarDTO customerdto);

        void Update(CarDTO customerdto);

        void Remove(int id);
    }
}
