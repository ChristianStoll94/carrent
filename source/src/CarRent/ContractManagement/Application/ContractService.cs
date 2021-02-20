using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ContractManagement.Domain;
using CarRent.ReservationManagement.Application;

namespace CarRent.ContractManagement.Application
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IReservationService _reservationService;
        public ContractService(IContractRepository contractRepository, IReservationService reservationService)
        {
            _contractRepository = contractRepository;
            _reservationService = reservationService;
        }
        public ContractDTO GetContract(int contractId)
        {
            var entity = _contractRepository.Get(contractId);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Contract)} {contractId} was not found");

            return new ContractDTO()
            {
                Id = entity.Id,
            };
        }

        public void DeleteContract(int reservationId)
        {
            _reservationService.DeleteReservation(reservationId);
        }

        public void CreateConract(int reservationId)
        {
            var reservation = _reservationService.GetReservation(reservationId);
            var contractDto = new ContractDTO()
            {
                ReservationId = reservation.Id,
                PickupDate = DateTime.Now,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                CustomerId = reservation.CustomerId,
                CarId = reservation.CarId,
                Price = reservation.Price,
            };

            _contractRepository.Add(contractDto);
            _reservationService.DeleteReservation(reservationId);
        }
    }
}
