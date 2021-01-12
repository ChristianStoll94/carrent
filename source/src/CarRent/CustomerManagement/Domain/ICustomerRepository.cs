using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CustomerManagement.Domain
{
    public interface ICustomerRepository
    {
        Customer FindById(int id);

        IEnumerable<Customer> FindByName(string name);

        void Add(Customer customer);

        void Update(Customer customer);

        void Remove(int id);
    }
}
