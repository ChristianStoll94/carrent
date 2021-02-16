using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public CarDTO GetCar(int carId)
        {
            var entity = _carRepository.Get(carId);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Car)} {carId} was not found");

            return new CarDTO()
            {
                Id = entity.Id,
                Typ = entity.Typ,
                Brand = entity.Brand,
                CarClassEnum = MapCar(entity.CarClass.Description)
            };
        }

        public IEnumerable<CarDTO> GetCarByFilter(CarDTO carDto)
        {
            return _carRepository.FindByFilter(carDto).Select(a => new CarDTO()
            {
                Id = a.Id,
                Typ = a.Typ,
                Brand = a.Brand,
                CarClassEnum = MapCar(a.CarClass.Description)
            }).ToList();
        }

        public void DeleteCar(int carId)
        {
            _carRepository.Remove(carId);
        }

        public void CreateCar(CarDTO carDto)
        {
            //ToDo:Validation
            _carRepository.Add(carDto);
        }

        public void UpdateCar(CarDTO carDto)
        {
            _carRepository.Update(carDto);
        }

        public CarClassEnum MapCar(string carClass)
        {
            return carClass switch
            {
                "Einfachklasse" => CarClassEnum.Einfach,
                "Mittelklasse" => CarClassEnum.Mittel,
                "Luxusklasse" => CarClassEnum.Luxus,
                _ => throw new NullReferenceException(),
            };
        }
    }
}
