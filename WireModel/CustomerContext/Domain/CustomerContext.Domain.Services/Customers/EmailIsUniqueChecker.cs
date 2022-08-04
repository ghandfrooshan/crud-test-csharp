using CustomerContext.Domain.Customers.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Services.Customers
{
    public class EmailIsUniqueChecker : IEmailIsUniqueChecker
    {
        private readonly ICustomerRepository customerRepository;

        public EmailIsUniqueChecker(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public bool IsAlreadyExist(string email)
        {
            return customerRepository.Contain(a => a.Email == email );

        }


    }
}
