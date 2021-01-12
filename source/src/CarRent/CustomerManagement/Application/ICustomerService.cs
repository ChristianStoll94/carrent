using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CustomerManagement.Application
{
    public interface ICustomerService
    {
        public CustomerDTO GetCustomer(int customerId);
    }
}
