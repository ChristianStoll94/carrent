using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ContractManagement.Application;

namespace CarRent.ContractManagement.Domain
{
    public interface IContractRepository
    {
        Contract Get(int id);

        void Add(ContractDTO contractDto);

        void Remove(int id);
    }
}
