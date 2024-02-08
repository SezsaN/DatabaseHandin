using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer CreateCustomer(string firstName, string lastName, string email, int addressId, int roleId)
        {
            var customer = _customerRepository.GetOne(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email &&  x.AddressId == addressId && x.RoleId == roleId);
            if (customer != null)
            {
                customer = _customerRepository.Create(new Customer { FirstName = firstName, LastName = lastName, Email = email, AddressId = addressId, RoleId = roleId});
            }
            return customer!;
        }

        public Customer GetCustomerByName(string firstName, string lastName)
        {
            var customer = _customerRepository.GetOne(x => x.FirstName == firstName && x.LastName == lastName);
            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _customerRepository.GetOne(x => x.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var updatedCustomer = _customerRepository.Update(x => x.Id == customer.Id, customer);
            return updatedCustomer;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetOne(x => x.Id == id);
            if (customer != null)
            {
                _customerRepository.Delete(x => x.Id == id);
                return true;
            }
            return false;
        }
    }
}
