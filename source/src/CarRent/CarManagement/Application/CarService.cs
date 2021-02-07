using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CarManagement.Application
{
    public class CarService : ICarService
    {
        public CarDTO GetCar(int carId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarDTO> GetCarByFilter(CarDTO carDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }

        public void CreateCar(CarDTO carDto)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(CarDTO carDto)
        {
            throw new NotImplementedException();
        }
    }
}
