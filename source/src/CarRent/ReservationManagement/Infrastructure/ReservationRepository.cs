using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Models.DBModels;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.ReservationManagement.Infrastructure
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly carrentContext _carrentContext;

        public ReservationRepository(carrentContext context)
        {
            _carrentContext = context;
        }

        public Reservation Get(int id)
        {
            var entity = _carrentContext.Reservation
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .FirstOrDefault(o => o.Id == id);
            return entity;
        }

        public double GetPrice(int carId)
        {
            return _carrentContext.Car.Where(i => i.Id == carId).Select(c => c.CarClass.Price).FirstOrDefault();
        }

        public void Add(ReservationDTO reservationDto)
        {
            if (_carrentContext.Reservation.FirstOrDefault(o => o.Id == reservationDto.Id) != null)
                throw new ArgumentException($"{reservationDto.Id} is taken");

            var reservation = new Reservation()
            {
                Id = reservationDto.Id,
                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate,
                Customer = _carrentContext.Customer.FirstOrDefault(o => o.Id == reservationDto.CarId),
                Car = _carrentContext.Car.FirstOrDefault(o => o.Id == reservationDto.CarId),
                Price = reservationDto.Price
            };

            _carrentContext.Reservation.Add(reservation);
            _carrentContext.SaveChanges();
        }

        public void Update(ReservationDTO reservationDto)
        {
            var entity = _carrentContext.Reservation.FirstOrDefault(o => o.Id == reservationDto.Id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Reservation)} {reservationDto.Id} was not found");

            entity.StartDate = reservationDto.StartDate;
            entity.StartDate = reservationDto.EndDate;
            entity.Car = _carrentContext.Car.FirstOrDefault(o => o.Id == reservationDto.CarId);

            _carrentContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _carrentContext.Reservation.FirstOrDefault(o => o.Id == id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Reservation)} {id} was not found");

            _carrentContext.Remove(entity);

            _carrentContext.SaveChanges();
        }
    }
}
