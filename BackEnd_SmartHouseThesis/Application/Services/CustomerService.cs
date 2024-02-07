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
        private readonly AccountService _accountService;

        public CustomerService(CustomerRepository customerRepository, AccountService accountService)
        {
            _customerRepository = customerRepository;
            _accountService = accountService;
        }

        public async Task UpdateCustomer(Customer customer) => await _customerRepository.UpdateAsync(customer);
        public async Task DeleteCustomer(Customer customer) => await _customerRepository.RemoveAsync(customer);
        public async Task<IQueryable<Customer>> GetAll() => await _customerRepository.FindAllAsync();
        public async Task<Customer> GetCustomer(Guid id) => await _customerRepository.GetAsync(id);
        public async Task CreateCustomer (Customer customer) => await _customerRepository.AddAsync(customer);

        public async Task CreateCustomer(Account account)
        {         
            try
            {
                var _account = await _accountService.GetAccountByEmail(account.Email);
                if(_account == null )
                {
                    _account = await _accountService.CreateAccount(account);
                    var customer = new Customer();
                    customer.Id = _account.Id;
                    customer.Account =_account;
                    customer.RoleName = "Customer";
                    await CreateCustomer(customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error At CreateCustomer Service");
            }           
        }
    }
}
