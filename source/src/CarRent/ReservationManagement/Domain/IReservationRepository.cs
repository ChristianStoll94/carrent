using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ReservationManagement.Application;

namespace CarRent.ReservationManagement.Domain
{
    public interface IReservationRepository
    {
        Reservation Get(int id);

        double GetPrice(int carId);

        void Add(ReservationDTO reservationDto);

        void Update(ReservationDTO reservationDto);

        void Remove(int id);
    }
}
