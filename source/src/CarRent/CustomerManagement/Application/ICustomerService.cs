using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CustomerManagement.Application
{
    public interface ICustomerService
    {
        public CustomerDTO GetCustomer(int customerId);
        public IEnumerable<CustomerDTO> GetCustomersByName(string name);
        public void DeleteCustomer(int customerId);
        public void CreateCustomer(CustomerDTO customer);
        public void UpdateCustomer(CustomerDTO customer);
    }
}
