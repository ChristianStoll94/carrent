using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.ContractManagement.Application
{
    public interface IContractService
    {
        public ContractDTO GetContract(int contractId);
        public void DeleteContract(int carId);
        public void CreateConract(int reservationId);

    }
}
