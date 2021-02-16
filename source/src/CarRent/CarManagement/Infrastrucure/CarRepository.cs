using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Domain;
using CarRent.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace CarRent.CarManagement.Infrastrucure
{
    public class CarRepository : ICarRepository
    {
        private readonly carrentContext _carrentContext;

        public CarRepository(carrentContext carrentContext)
        {
            _carrentContext = carrentContext;
        }

        public Car Get(int id)
        {
            var entity = _carrentContext.Car
                .Include(c => c.CarClass)
                .FirstOrDefault(o => o.Id == id);
            return entity;
        }

        public IEnumerable<Car> FindByFilter(CarDTO car)
        {
            var entity = _carrentContext.Car
                .Where(o => car.Brand == null || o.Brand == car.Brand)
                .Where(o => car.Typ == null || o.Typ == car.Typ) 
                .Where(o => car.CarClassEnum == null || o.CarClass.Description == MapCarClass(car.CarClassEnum))
                .Include(c => c.CarClass)
                .ToList();
            return entity;
        }

        public void Add(CarDTO carDto)
        {
            if (_carrentContext.Car.FirstOrDefault(o => o.Id == carDto.Id) != null)
                throw new ArgumentException($"{carDto.Id} is taken");

            var car = new Car()
            {
                Id = carDto.Id,
                Typ = carDto.Typ,
                Brand = carDto.Brand,
                CarClass = _carrentContext.CarClass.FirstOrDefault(o => o.Description == MapCarClass(carDto.CarClassEnum))
            };

            _carrentContext.Car.Add(car);
            _carrentContext.SaveChanges();
        }

        public void Update(CarDTO carDto)
        {
            var entity = _carrentContext.Car.FirstOrDefault(o => o.Id == carDto.Id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Car)} {carDto.Id} was not found");

            entity.Brand = carDto.Brand;
            entity.Typ = carDto.Typ;
            entity.CarClass =
                _carrentContext.CarClass.FirstOrDefault(o => o.Description == MapCarClass(carDto.CarClassEnum));

            _carrentContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _carrentContext.Car.FirstOrDefault(o => o.Id == id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Car)} {id} was not found");

            _carrentContext.Remove(entity);

            _carrentContext.SaveChanges();
        }

        public string MapCarClass(CarClassEnum? carClassEnum)
        {
            return carClassEnum switch
            {
                CarClassEnum.Einfach => "Einfachklasse",
                CarClassEnum.Mittel => "Mittelklasse",
                CarClassEnum.Luxus => "Luxusklasse",
                _ => null,
            };
        }
    }
}
