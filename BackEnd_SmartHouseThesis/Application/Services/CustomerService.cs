using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task UpdateCustomer(Customer customer) => await _customerRepository.UpdateAsync(customer);
        public async Task DeleteCustomer(Customer customer) => await _customerRepository.RemoveAsync(customer);
        public async Task<IQueryable<Customer>> GetAll() => await _customerRepository.FindAllAsync();
        public async Task<Customer> GetCustomer(Guid id) => await _customerRepository.GetAsync(id);
        public async Task CreateCustomer(Customer customer) => await _customerRepository.AddAsync(customer);
    }
}
