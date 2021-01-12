using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CustomerManagement.Domain;
using CarRent.Models.DBModels;

namespace CarRent.CustomerManagement.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly carrentContext _carrentContext;

        public CustomerRepository(carrentContext context)
        {
            _carrentContext = context;
        }

        public Customer FindById(int id)
        {
            var customer = _carrentContext.Customer.FirstOrDefault(o => o.Id == id);
            return customer;
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
