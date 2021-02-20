using CarRent.ContractManagement.Application;
using CarRent.ContractManagement.Domain;
using CarRent.Models.DBModels;
using System;
using System.Linq;

namespace CarRent.ContractManagement.Infrastructure
{
    public class ContractRepository : IContractRepository
    {
        private readonly carrentContext _carrentContext;

        public ContractRepository(carrentContext context)
        {
            _carrentContext = context;
        }

        public Contract Get(int id)
        {
            var entity = _carrentContext.Contract
                .FirstOrDefault(o => o.Id == id);
            return entity;
        }

        public void Add(ContractDTO contractDto)
        {
            var contract = new Contract()
            {
                ReservationId = contractDto.ReservationId,
                PickupDate = contractDto.PickupDate,
                StartDate = contractDto.StartDate,
                EndDate = contractDto.EndDate,
                Customer = _carrentContext.Customer.FirstOrDefault(o => o.Id == contractDto.CarId),
                Car = _carrentContext.Car.FirstOrDefault(o => o.Id == contractDto.CarId),
                Price = contractDto.Price
            };

            _carrentContext.Contract.Add(contract);
            _carrentContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _carrentContext.Contract.FirstOrDefault(o => o.Id == id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Contract)} {id} was not found");

            _carrentContext.Remove(entity);

            _carrentContext.SaveChanges();
        }
    }
}
