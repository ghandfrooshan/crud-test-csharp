using CustomerContext.Domain.Customers.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Services.Customers
{
    public class CustomerIsUniqueChecker : ICustomerIsUniqueChecker
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerIsUniqueChecker(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public bool IsAlreadyExist(string firstName, string lastName, DateTime dateOfBirth)
        {
            return customerRepository.Contain(a => a.FirstName == firstName && a.LastName==lastName&& a.DateOfBirth==dateOfBirth);
        }
    }
}
