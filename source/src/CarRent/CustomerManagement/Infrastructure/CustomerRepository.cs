using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CustomerManagement.Application;
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

        public Customer Get(int id)
        {
            var entity = _carrentContext.Customer.FirstOrDefault(o => o.Id == id);
            return entity;
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            var entity = _carrentContext.Customer.Where(o => o.Name == name).ToList();
            return entity;
        }

        public void Add(CustomerDTO customerDto)
        {
            if (_carrentContext.Customer.FirstOrDefault(o => o.Id == customerDto.Id) != null)
                throw new ArgumentException($"{customerDto.Id} is taken");

            var customer = new Customer()
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Address = customerDto.Address
            };

            _carrentContext.Customer.Add(customer);
            _carrentContext.SaveChanges();
        }

        public void Update(CustomerDTO customerDto)
        {
            var entity = _carrentContext.Customer.FirstOrDefault(o => o.Id == customerDto.Id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Customer)} {customerDto.Id} was not found");

            entity.Name = customerDto.Name;
            entity.Address = customerDto.Address;

            _carrentContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _carrentContext.Customer.FirstOrDefault(o => o.Id == id);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Customer)} {id} was not found");

            _carrentContext.Remove(entity);

            _carrentContext.SaveChanges();
        }
    }
}
