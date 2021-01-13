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

        public Customer FindById(int id)
        {
            var entity = _carrentContext.Customer.FirstOrDefault(o => o.Id == id);
            return entity;
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            var entity = _carrentContext.Customer.Where(o => o.Name == name).ToList();
            return entity;
        }

        public void Add(CustomerDTO customerdto)
        {
            var customer = new Customer()
            {
                Id = customerdto.Id,
                Name = customerdto.Name,
                Address = customerdto.Address
            };
            _carrentContext.Customer.Add(customer);
            _carrentContext.SaveChanges();
        }

        public void Update(CustomerDTO customerdto)
        {
            var entity = _carrentContext.Customer.FirstOrDefault(o => o.Id == customerdto.Id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            entity.Name = customerdto.Name;
            entity.Address = customerdto.Address;

            _carrentContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _carrentContext.Customer.FirstOrDefault(o => o.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            _carrentContext.Remove(entity);

            _carrentContext.SaveChanges();
        }
    }
}
