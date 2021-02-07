using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CarManagement.Application
{
    public interface ICarService
    {
        public CarDTO GetCar(int carId);
        public IEnumerable<CarDTO> GetCarByFilter(CarDTO carDto);
        public void DeleteCar(int carId);
        public void CreateCar(CarDTO carDto);
        public void UpdateCar(CarDTO carDto);
    }
}
