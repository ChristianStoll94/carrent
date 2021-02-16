using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.ReservationManagement.Application
{
    public interface IReservationService
    {
        public ReservationDTO GetReservation(int reservationId);
        public double GetPrice(CalculationQuery calculationQuery);
        public void DeleteReservation(int reservationId);
        public void CreateReservation(ReservationDTO reservationDto);
        public void UpdateReservation(ReservationDTO reservationDto);
    }
}
