using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CarRent.CustomerManagement.Domain;

namespace CarRent.CustomerManagement.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDTO GetCustomer(int customerId)
        {
            var entity = _customerRepository.Get(customerId);

            if (entity == null)
                throw new NullReferenceException($"Entity {nameof(Customer)} {customerId} was not found");
            
            return new CustomerDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address
            };
        }

        public IEnumerable<CustomerDTO> GetCustomersByName(string name)
        {
            return _customerRepository.FindByName(name).Select(a => new CustomerDTO()
            {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address
            }).ToList();
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.Remove(customerId);
        }

        public void CreateCustomer(CustomerDTO customerDto)
        {
            if (string.IsNullOrEmpty(customerDto.Name))
            {
                throw new ArgumentNullException($"{nameof(customerDto.Name)} can not be null");
            }
            if (string.IsNullOrEmpty(customerDto.Address))
            {
                throw new ArgumentNullException($"{nameof(customerDto.Address)} can not be null");
            }

            _customerRepository.Add(customerDto);
        }

        public void UpdateCustomer(CustomerDTO customerDto)
        {
            _customerRepository.Update(customerDto);
        }
    }
}
