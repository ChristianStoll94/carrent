using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ReservationManagement.Domain;

namespace CarRent.ReservationManagement.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository carRepository)
        {
            _reservationRepository = carRepository;
        }
        public ReservationDTO GetReservation(int reservationId)
        {
            var entity = _reservationRepository.Get(reservationId);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Reservation)} {reservationId} was not found");

            return new ReservationDTO()
            {
                Id = entity.Id,
                CarId = entity.Car.Id,
                CustomerId = entity.Customer.Id,
                EndDate = entity.EndDate,
                Price = entity.Price,
                StartDate = entity.StartDate
            };
        }

        public double GetPrice(CalculationQuery calculationQuery)
        {
            return CalculatePrice(calculationQuery.CarId, calculationQuery.Days);
        }

        public void DeleteReservation(int reservationId)
        {
            _reservationRepository.Remove(reservationId);
        }

        public void CreateReservation(ReservationDTO reservationDto)
        {
            var days = (int)(reservationDto.EndDate - reservationDto.StartDate).TotalDays;
            reservationDto.Price = CalculatePrice(reservationDto.CarId, days);

            _reservationRepository.Add(reservationDto);
        }

        public void UpdateReservation(ReservationDTO reservationDto)
        {
            _reservationRepository.Update(reservationDto);
        }

        public double CalculatePrice(int carId, int days)
        {
            return days * _reservationRepository.GetPrice(carId);
        }
    }
}
