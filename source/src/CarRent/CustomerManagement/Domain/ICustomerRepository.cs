using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CustomerManagement.Application;

namespace CarRent.CustomerManagement.Domain
{
    public interface ICustomerRepository
    {
        Customer FindById(int id);

        IEnumerable<Customer> FindByName(string name);

        void Add(CustomerDTO customerdto);

        void Update(CustomerDTO customerdto);

        void Remove(int id);
    }
}
